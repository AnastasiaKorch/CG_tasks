#include <gl\glew.h>
#include <gl\freeglut.h>
#include "SOIL.h"
#include <iostream>
#include <vector>
#include <string> 
#include <fstream>
#include "glm\glm.hpp"

int width = 650;
int height = 650;

std::vector< glm::vec3 > vertices;
std::vector< glm::vec2 > uvs;
std::vector< glm::vec3 > normals;
std::vector < GLuint > indeces;

std::vector<int> textures = std::vector<int>();
GLuint Program;
//материал освещение 
GLint u_diffuse;
GLint u_ambient;
GLint u_shininess;
//перемещение
GLint u_shift;
GLint u_scale;
GLint u_rotation;
//положение источника света
GLint u_spotDirection;
GLint u_spotAngle;
GLint u_lightType;
//текстуры
GLint u_texture;
GLint u_normal;
GLint u_textCoord;

const int ROTATION_FLAG = 0;
const int MOVE_FLAG = 1;
const int LIGHT_MOVE_FLAG = 2;

int flag = 0, light_type = 0;


float light_position[3] = { 0.0, 0.0, 0.0 };
float spot_direction[3] = { 0.0, 0.0, -1.0 };

void checkOpenGLerror()
{
	GLenum errCode;
	if ((errCode = glGetError()) != GL_NO_ERROR)
		std::cout << "OpenGl error! - " << gluErrorString(errCode);
}

//изменяет положение обьектов
char * vshader =
"varying vec2 vtexcoord;\n"
"varying vec3 vertex;\n"
"varying vec3 normal;\n"
"uniform vec3 rotation;\n"
"uniform vec3 shift;\n"
"uniform vec3 scale;\n"
"void main(void) {\n"
"	mat4 rx = mat4(1, 0, 0, 0, 0, cos(rotation.x), -sin(rotation.x), 0, 0, sin(rotation.x), cos(rotation.x), 0, 0, 0, 0, 1);\n"
"	mat4 ry = mat4(cos(rotation.y), 0, sin(rotation.y), 0, 0, 1, 0, 0, -sin(rotation.y), 0, cos(rotation.y), 0, 0, 0, 0, 1);\n"
"	mat4 rz = mat4(cos(rotation.z), -sin(rotation.z), 0, 0, sin(rotation.z), cos(rotation.z), 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);\n"
"	mat4 sc = mat4(scale.x, 0, 0, 0, 0, scale.y, 0, 0, 0,0,scale.z,0, 0, 0, 0, 1);\n"
"   vtexcoord = vec2(gl_MultiTexCoord0);\n"
"	normal = normalize((vec4(normalize(gl_NormalMatrix * gl_Normal), 1.0) * rx * ry * rz).xyz);\n"
"	vec4 rotated = gl_Vertex * rx * ry * rz;\n"
"	vec4 shift4 = vec4(shift,1);\n"
"	vertex = vec3(gl_ModelViewProjectionMatrix * (rotated * sc + shift4));\n"
"	gl_Position = gl_ModelViewProjectionMatrix * (rotated * sc + shift4);\n"
"}\n";

//фрагментный шейдер, отвечает за оттенки, цвет, материал
char * fshader =
"uniform sampler2D myTexture;\n"
"uniform vec4 diffuse;\n"
"uniform vec4 ambient;\n"
"uniform vec4 shininess;\n"
"uniform sampler2D normalMap;\n"
"varying vec2 vtexcoord;\n"
"varying vec3 vertex;\n"
"varying vec3 normal;\n"
"uniform int lightType;\n"
"uniform vec3 spotDirection;\n"
"uniform float spotAngle;\n"
"void main(void) {\n"
"	float intensity = 3.0;\n"
"	vec4 color = vec4(vec3(0.0,0.0,0.0),1.0);\n"
"	float diffusecoef = 1.0;\n"
"	for (int i = 0; i < gl_MaxLights; ++i) {\n"
"		vec3 surfaceToLight;\n"
"		float attenuation = -10.0;\n"
"		if (lightType == 0 || lightType == 1) {\n"
"			surfaceToLight = normalize(gl_LightSource[i].position.xyz - vertex);\n"
"			float distanceToLight = length(gl_LightSource[i].position.xyz - vertex);\n"
"			attenuation = 1 / (1.0 + pow(distanceToLight,0.5));\n"
"			diffusecoef = max(0.0, dot(normal, surfaceToLight))* 1.2;\n"
"		}\n"
"		if (lightType == 1) {\n"
"			float lightToSurfaceAngle = degrees(acos(dot(-surfaceToLight, normalize(spotDirection))));\n"
"			if (lightToSurfaceAngle > spotAngle) attenuation =1.0/lightToSurfaceAngle;\n"
"		}\n"
"		vec4 lambient = vec4(10 * intensity * ambient * gl_FrontLightProduct[i].ambient);\n"
"		vec3 ldiffuse = vec3(intensity * diffusecoef * gl_FrontLightProduct[i].diffuse * texture2D(myTexture, vtexcoord).rgb);\n"
"		vec3 refl = vec3(reflect(-surfaceToLight, normal));\n"
"		color += vec4(vec3(lambient.rgb + attenuation * diffuse * ldiffuse ), 1.0);\n"
"	}\n"
"	gl_FragColor = color * 2;\n"
"}\n";

bool loadOBJ(
	const char * path,
	std::vector < glm::vec3 > & out_vertices,
	std::vector < glm::vec2 > & out_uvs,
	std::vector < glm::vec3 > & out_normals,
	std::vector < GLuint > & out_indeces
	)
{
	std::vector< unsigned int > vertexIndices, uvIndices, normalIndices;
	std::vector< glm::vec3 > temp_vertices;
	std::vector< glm::vec2 > temp_uvs;
	std::vector< glm::vec3 > temp_normals;

	FILE * file = fopen(path, "r");
	if (file == NULL) {
		printf("Impossible to open the file !\n");
		return false;
	}

	while (1) {

		char lineHeader[128];
		// read the first word of the line
		int res = fscanf(file, "%s", lineHeader);
		if (res == EOF)
			break; // EOF = End Of File. Quit the loop.

		//вершины
		if (strcmp(lineHeader, "v") == 0) {
			glm::vec3 vertex;
			fscanf(file, "%f %f %f\n", &vertex.x, &vertex.y, &vertex.z);
			temp_vertices.push_back(vertex);
		}

		//координаты uv
		else if (strcmp(lineHeader, "vt") == 0) {
			glm::vec2 uv;
			fscanf(file, "%f %f\n", &uv.x, &uv.y);
			temp_uvs.push_back(uv);
		}

		//нормали
		else if (strcmp(lineHeader, "vn") == 0) {
			glm::vec3 normal;
			fscanf(file, "%f %f %f\n", &normal.x, &normal.y, &normal.z);
			temp_normals.push_back(normal);
		}

		//грани
		else if (strcmp(lineHeader, "f") == 0) {
			std::string vertex1, vertex2, vertex3;
			unsigned int vertexIndex[3], uvIndex[3], normalIndex[3];
			int matches = fscanf(file, "%d/%d/%d %d/%d/%d %d/%d/%d\n", &vertexIndex[0], &uvIndex[0], &normalIndex[0], &vertexIndex[1], &uvIndex[1], &normalIndex[1], &vertexIndex[2], &uvIndex[2], &normalIndex[2]);
			if (matches != 9) {
				printf("File can't be read by our simple parser : ( Try exporting with other options\n");
				return false;
			}
			vertexIndices.push_back(vertexIndex[0]);
			vertexIndices.push_back(vertexIndex[1]);
			vertexIndices.push_back(vertexIndex[2]);
			uvIndices.push_back(uvIndex[0]);
			uvIndices.push_back(uvIndex[1]);
			uvIndices.push_back(uvIndex[2]);
			normalIndices.push_back(normalIndex[0]);
			normalIndices.push_back(normalIndex[1]);
			normalIndices.push_back(normalIndex[2]);
		}
	}

	for (unsigned int i = 0; i < vertexIndices.size(); i++) {
		unsigned int vertexIndex = vertexIndices[i];
		glm::vec3 vertex = temp_vertices[vertexIndex - 1];
		out_vertices.push_back(vertex);
		out_indeces.push_back(vertexIndex - 1);
	}
	for (unsigned int i = 0; i < uvIndices.size(); i++) {
		auto uvIndex = uvIndices[i];
		auto uv = temp_uvs[uvIndex - 1];
		out_uvs.push_back(uv);
	}
	for (unsigned int i = 0; i < normalIndices.size(); i++) {
		auto normalIndex = normalIndices[i];
		auto normal = temp_normals[normalIndex - 1];
		out_normals.push_back(normal);
	}
}


void initShader()
{
	const char* vsSource = vshader;//перемещения
	const char* fsSource = fshader;//фрагменты

	GLuint vShader = 0, fShader = 0;

	//вершинный шейдер
	vShader = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(vShader, 1, &vsSource, NULL);
	glCompileShader(vShader);

	fShader = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(fShader, 1, &fsSource, NULL);
	glCompileShader(fShader);

	Program = glCreateProgram();
	glAttachShader(Program, vShader);
	glAttachShader(Program, fShader);

	glLinkProgram(Program);

	int link_ok;
	glGetProgramiv(Program, GL_LINK_STATUS, &link_ok);

	if (!link_ok)
	{
		std::cout << "error attach shaders\n";
		return;
	}

	u_diffuse = glGetUniformLocation(Program, "diffuse");
	u_shift = glGetUniformLocation(Program, "shift");
	u_scale = glGetUniformLocation(Program, "scale");
	u_rotation = glGetUniformLocation(Program, "rotation");
	u_spotDirection = glGetUniformLocation(Program, "spotDirection");
	u_spotAngle = glGetUniformLocation(Program, "spotAngle");
	u_lightType = glGetUniformLocation(Program, "lightType");
	u_normal = glGetUniformLocation(Program, "normalMap");
	u_texture = glGetUniformLocation(Program, "myTexture");

	checkOpenGLerror();
}

void freeShader()
{
	glUseProgram(0);
	glDeleteProgram(Program);
}

void drawHead()
{
	for (auto i = 0; i < vertices.size(); i += 3) {

		glBegin(GL_TRIANGLES);

		glNormal3f(normals[i].x, normals[i].y, normals[i].z);
		glTexCoord2f(uvs[i].x, uvs[i].y);
		glVertex3f(vertices[i].x, vertices[i].y, vertices[i].z);

		glNormal3f(normals[i + 1].x, normals[i + 1].y, normals[i + 1].z);
		glTexCoord2f(uvs[i + 1].x, uvs[i + 1].y);
		glVertex3f(vertices[i + 1].x, vertices[i + 1].y, vertices[i + 1].z);

		glNormal3f(normals[i + 2].x, normals[i + 2].y, normals[i + 2].z);
		glTexCoord2f(uvs[i + 2].x, uvs[i + 2].y);
		glVertex3f(vertices[i + 2].x, vertices[i + 2].y, vertices[i + 2].z);

		/*glm::vec3 deltaPos1 = normals[i + 1] - normals[i];
		glm::vec3 deltaPos2 = normals[i + 2] - normals[i];

		glm::vec2 deltaUV1 = uvs[i + 1] - uvs[i];
		glm::vec2 deltaUV2 = uvs[i + 2] - uvs[i];*/

		glEnd();
	}
}

int loadTexture()
{
	textures.push_back(SOIL_load_OGL_texture
		(
			"5.png",
			SOIL_LOAD_AUTO,
			SOIL_CREATE_NEW_ID,
			SOIL_FLAG_INVERT_Y
			));
	textures.push_back(SOIL_load_OGL_texture
		(
			"2.png",
			SOIL_LOAD_AUTO,
			SOIL_CREATE_NEW_ID,
			SOIL_FLAG_INVERT_Y
			));

	for (auto a = textures.begin(); a != textures.end(); ++a)
		if (!(*a))
		{
			std::cout << ("SOIL loading error: '%s'\n", SOIL_last_result());
			return  0;
		}

	return 1;
}

void bindTexture(int i)
{
	glBindTexture(GL_TEXTURE_2D, textures[i]);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
}

static float Diffuse[4] = { 1.0, 1.0, 1.0, 1.0 };//материал левой головы
static float Diffuse2[4] = { 0.5, 0.4, 0.4, 1.0 };//материал правой головы
static float shift[3] = { -1,0,-3 }; // смещение 1 
static float shift2[3] = { 1,0,-3 };// смещение 2
static float scale[3] = { 1,1,1 }; // масштаб
float rotation[3] = { 0,0,0 }; // вращение

void render()
{
	glUseProgram(Program);

	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();

	
		//gluPerspective(50.0, win_width / win_height, 1.0, 35.0);
		gluPerspective(65.f, width / height, 1.f, 1000.f);
		//gluLookAt(0., 2., 2., 0., 0., 0., 0., 1., 0.);
		gluLookAt(15., 15., 35., 0., 0., 0., 0., 1., 0.);
	
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();

	glPushMatrix();
	glLightfv(GL_LIGHT0, GL_POSITION, light_position);
	glPopMatrix();
	

	glUniform1i(u_lightType, light_type); // тип света
	glUniform1f(u_spotAngle, 10); // угол освещения
	glUniform3fv(u_spotDirection, 1, spot_direction); // направление осчвещения


	glUniform1i(u_texture, 0);
	glUniform1i(u_normal, 1);

	bindTexture(0); // левая голова

	glUniform4fv(u_diffuse, 1, Diffuse);
	glUniform4fv(u_ambient, 1, Diffuse);
	glUniform4fv(u_shininess, 1, Diffuse);
	glUniform3fv(u_rotation, 1, rotation);
	glUniform3fv(u_scale, 1, scale);
	glUniform3fv(u_shift, 1, shift);

	drawHead();

	/*bindTexture(1); // правая голова

	glUniform4fv(u_diffuse, 1, Diffuse2);
	glUniform4fv(u_ambient, 1, Diffuse2);
	glUniform4fv(u_shininess, 1, Diffuse2);
	float v[3] = { rotation[0], -rotation[1], rotation[2] };

	glUniform3fv(u_rotation, 1, v);
	glUniform3fv(u_scale, 1, scale);
	glUniform3fv(u_shift, 1, shift2);

	drawHead();*/

	glUseProgramObjectARB(0);

	glColor3f(0.0, 0.3, 0.9);

	 glBegin(GL_QUADS);// низ сцены(пол)
	glVertex3f(-10, -1, -100);
	glVertex3f(-10, -1, 100);
	glVertex3f(10, -1, 100);
	glVertex3f(10, -1, -100);

	glEnd();

	glFlush();

	glutSwapBuffers();
}

void special_keys(int key, int x, int y)
{
	switch (key)
	{
	case GLUT_KEY_F1: flag = ROTATION_FLAG; return;//
	case GLUT_KEY_F2:flag = MOVE_FLAG; return;
	case GLUT_KEY_F3:flag = LIGHT_MOVE_FLAG; return;
	case GLUT_KEY_F4:light_type = (light_type + 1) % 2; return;
	}

	switch (flag)
	{
		// вращение объектов сцены
	case ROTATION_FLAG:
	{
		switch (key) {
		case GLUT_KEY_UP: rotation[0] += 0.1; break;
		case GLUT_KEY_DOWN: rotation[0] -= 0.1; break;
		case GLUT_KEY_RIGHT: rotation[1] += 0.1; break;
		case GLUT_KEY_LEFT: rotation[1] -= 0.1; break;
		case GLUT_KEY_PAGE_UP: rotation[2] += 0.1; break;
		case GLUT_KEY_PAGE_DOWN: rotation[2] -= 0.1; break;
		}
	}
	break;

	// перемещение объектов сцены
	case MOVE_FLAG:
	{
		switch (key) {
		case GLUT_KEY_UP: shift[1] += 0.1; shift2[1] -= 0.1; break;
		case GLUT_KEY_DOWN: shift[1] -= 0.1;   shift2[1] += 0.1; break;
		case GLUT_KEY_RIGHT: shift[0] += 0.1;   shift2[0] -= 0.1; break;
		case GLUT_KEY_LEFT: shift[0] -= 0.1;  shift2[0] += 0.1; break;
		case GLUT_KEY_PAGE_UP: shift[2] += 0.1; shift2[2] -= 0.1;  break;
		case GLUT_KEY_PAGE_DOWN: shift[2] -= 0.1; shift2[2] += 0.1;  break;
		}
	}
	break;

	// F3 нажата перемещение источника света
	case LIGHT_MOVE_FLAG:
	{
		switch (key) {
		case GLUT_KEY_UP: light_position[1] += 1.1; break;
		case GLUT_KEY_DOWN: light_position[1] -= 1.1; break;
		case GLUT_KEY_RIGHT: light_position[0] += 1.1; break;
		case GLUT_KEY_LEFT: light_position[0] -= 1.1; break;
		case GLUT_KEY_PAGE_UP: light_position[2] += 1.1; break;
		case GLUT_KEY_PAGE_DOWN: light_position[2] -= 1.1; break;
		}
	}
	break;
	}

	glutPostRedisplay();
}

// первоначальная инициализация параметров
void init()
{
	glClearColor(0.9, 0.9, 0.9, 0.1);
	glEnable(GL_DEPTH_TEST);
	glShadeModel(GL_SMOOTH);
	glEnable(GL_NORMALIZE);
}

// при изменении размеров экрана
void reshape(int width, int height)
{
	double w = width;
	double h = height;

	glViewport(0, 0, w, h);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(65.0f, w / h, 1.0f, 100.0f);
	glMatrixMode(GL_MODELVIEW);
}

void main(int argc, char **argv)
{
	glutInit(&argc, argv);
	glutInitWindowSize(width, height);
	glutInitWindowPosition((glutGet(GLUT_SCREEN_WIDTH) - width) / 2, (glutGet(GLUT_SCREEN_HEIGHT) - height) / 2);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_RGBA | GLUT_ALPHA | GLUT_DOUBLE);
	glutCreateWindow("Лабораторная 12");

	glutDisplayFunc(render);
	glutSpecialFunc(special_keys);

	init();
	loadTexture();

	GLint GlewInitResult = glewInit();
	if (GLEW_OK != GlewInitResult)
	{
		printf("ERROR: %s\n", glewGetErrorString(GlewInitResult));
		exit(EXIT_FAILURE);
	}

	initShader();
	glutReshapeFunc(reshape);

	if (!loadOBJ("ScoobyDoo.obj", vertices, uvs, normals, indeces)) 
		std::cout << " ОШИБКА \n";

	glutMainLoop();
}