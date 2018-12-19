#include <gl/glew.h>
#include <gl/freeglut.h>
#include <iostream>

float width, height;
int flag = 0;
int verflag = 0;

static float scaleX[2] = { 0.5f, 1.0f };
static  float scaleY[2] = { 1.0f, 0.5f };
static float axis[3] = { 0.0f, 1.0f, 0.0f };
static float angle[1] = { 5.0f };
static float transport[3] = { 0.1f, 0.2f, 0.3f };


GLuint Program;
GLint  Attrib_vertex, Unif_color, Unif_scaleX, Unif_scaleY, Unif_angle, Unif_axis, Unif_transport, Unif_resolution, Unif_width;

void shaderLog(unsigned int shader)
{
	int   infologLen = 0;
	int   charsWritten = 0;
	char *infoLog;

	glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);

	if (infologLen > 1)
	{
		infoLog = new char[infologLen];
		if (infoLog == NULL)
		{
			std::cout << "ERROR: Could not allocate InfoLog buffer\n";
			exit(1);
		}
		glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog);
		std::cout << "InfoLog: " << infoLog << "\n\n\n";
		delete[] infoLog;
	}
}

void checkOpenGLerror()
{
	GLenum errCode;
	if ((errCode = glGetError()) != GL_NO_ERROR)
		std::cout << "OpenGl error! - " << gluErrorString(errCode);
}

const char * shader0 =
"attribute vec2 coord;\n"
"void main() {\n"
"  gl_Position = vec4(coord, 0.0, 1.0);\n"
"}\n";

//----------------------------------------------------------------------------------------

/****** Вершинные шейдеры ******/

// масштабирование на заданный коэффициент отдельно вдоль осей X и Y.
const char * shader1_1 = 
"uniform vec2 scaleX;\n"
"void main() {\n"
"	gl_Position = gl_ModelViewProjectionMatrix * vec4(gl_Vertex.x * scaleX.x, gl_Vertex.y, gl_Vertex.z, 1.0);\n"
"}\n";

const char * shader1_2 =
"uniform vec2 scaleY;\n"
"void main() {\n"
"	gl_Position = gl_ModelViewProjectionMatrix * vec4(gl_Vertex.x, gl_Vertex.y * scaleY.y, gl_Vertex.z, 1.0);\n"
"}\n"
;

// поворот вокруг задаваемой оси на задаваемый угол (X)
const char * shader2 =
"uniform float angle;\n"
"mat3 A = mat3(cos(angle), sin(angle), 0, -sin(angle), cos(angle), 0, 0, 0, 0);\n"
"vec3 VertexPosition = vec3(gl_Vertex.x, gl_Vertex.y , gl_Vertex.z);\n"
"void main() {\n"
"	gl_Position = vec4(VertexPosition * A, 1); }\n";

//  перенос на задаваемый вектор
const char * shader3 = 
"uniform vec3 transport;\n"
"void main () { \n"
"	gl_Position = vec4(gl_Vertex.x + transport.x, gl_Vertex.y + transport.y, gl_Vertex.z + transport.z, 1.0);\n"
"}\n"
;

//--------------------------------------------------------------------------------

/****** Фрагментные шейдеры ******/

// сплошная заливка (цвет передается из программы на С++)
const char * shader4 =
"uniform vec4 color;\n"
"void main() {\n"
"  gl_FragColor = color;\n"
"}\n";

// градиентная заливка (в любом направлении)
const char * shader5 =
"uniform  vec2 resolution;\n"
"vec2 position = (gl_FragCoord.xy / resolution.xy);\n"
"vec4 top = vec4(1.0, 0.0, 1.0, 1.0);\n"
"vec4 bottom = vec4(1.0, 1.0, 0.0, 1.0);\n"
"void main() {\n"
"gl_FragColor = vec4(mix(bottom, top, position.y));\n"
"}\n";

// заливка штриховкой: горизонтальная, вертикальная, диагональная (цвета и ширина полос передаются)
const char * shader7_1 =
"uniform float width;"
"uniform vec4 color;\n"
"void main() {\n"
"	float tmp = round(gl_FragCoord.x / width);\n"
"	if (floor(tmp - floor(tmp / 2.0)*2.0) == 0) {\n"
"		gl_FragColor = color; }\n"
"	else {\n"
"		gl_FragColor = vec4(1.0, 1.0, 0.0, 1.0);}\n"
"}\n"
;

const char * shader7_2 =
"uniform float width;"
"uniform vec4 color;\n"
"void main() {\n"
"	float tmp = round(gl_FragCoord.y / width);\n"
"	if (floor(tmp - floor(tmp / 2.0)*2.0) == 0) {\n"
"		gl_FragColor = color; }\n"
"	else {\n"
"		gl_FragColor = vec4(1.0, 1.0, 0.0, 1.0);}\n"
"}\n"
;

const char * shader7_3 =
"uniform float width;"
"uniform vec4 color;\n"
"void main() {\n"
"	float tmp = round((gl_FragCoord.x + gl_FragCoord.y) / width);\n"
"	if (floor(tmp - floor(tmp / 2.0)*2.0) == 0) {\n"
"		gl_FragColor = color; }\n"
"	else {\n"
"		gl_FragColor = vec4(1.0, 1.0, 0.0, 1.0);}\n"
"}\n"
;

void initShader()
{ 
	const char* vsSource;
	const char* fsSource;

	switch (verflag)
	{
	case 0:
		vsSource = shader1_1;
		break;
	case 1:
		vsSource = shader1_2;
		break;
	case 2:
		vsSource = shader2;
		break;
	case 3:
		vsSource = shader3;
		break;

	}

	// менять названия шейдеров для демонстрации
	switch (flag)
	{
	case 0:
		fsSource = shader4;
		break;
	case 1:
		fsSource = shader5;
		break;
	case 2:
		fsSource = shader7_1;
		break;
	case 3:
		fsSource = shader7_2; 
		break;
	case 4:
		fsSource = shader7_3;
		break;
	case 5:
		fsSource = shader7_3;
		break;
	default:
		break;
	} 
	
	GLuint vShader, fShader;

	vShader = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(vShader, 1, &vsSource, NULL);
	glCompileShader(vShader);

	std::cout << "vertex shader \n";
	shaderLog(vShader);

	fShader = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(fShader, 1, &fsSource, NULL);
	glCompileShader(fShader);

	std::cout << "fragment shader \n";
	shaderLog(fShader);

	Program = glCreateProgram();
	glAttachShader(Program, vShader);
	glAttachShader(Program, fShader);

	glLinkProgram(Program);

	int link_ok;
	glGetProgramiv(Program, GL_LINK_STATUS, &link_ok);
	if (!link_ok)
	{
		std::cout << "error attach shaders \n";
		return;
	}

	Attrib_vertex = glGetAttribLocation(Program, "coord");
	Unif_color = glGetUniformLocation(Program, "color");
	Unif_scaleX = glGetUniformLocation(Program, "scaleX");
	Unif_scaleY = glGetUniformLocation(Program, "scaleY");
	Unif_axis = glGetUniformLocation(Program, "axis");
	Unif_angle = glGetUniformLocation(Program, "angle");
	Unif_transport = glGetUniformLocation(Program, "transport");
	Unif_resolution = glGetUniformLocation(Program, "resolution");
	Unif_width = glGetUniformLocation(Program, "width");

	checkOpenGLerror();
}


void freeShader()
{
	glUseProgram(0);
	glDeleteProgram(Program);
}

void resizeWindow(int w, int h)
{
	width = w;
	height = h;
	glViewport(0, 0, width, height);
}

void render()
{
	glClear(GL_COLOR_BUFFER_BIT);
	glUseProgram(Program);


	glUniform2fv(Unif_scaleX, 1, scaleX);

	glUniform2fv(Unif_scaleY, 1, scaleY);

	glUniform3fv(Unif_axis, 1, axis);

	glUniform1fv(Unif_angle, 1, angle);

	glUniform3fv(Unif_transport, 1, transport);

	//-----------------------------------------------------

	static float color[4] = { 1.0f, 0.0f, 0.0f, 1.0f };
	glUniform4fv(Unif_color, 1, color);

	static float resolution[2] = { width, height };
	glUniform2fv(Unif_resolution, 1, resolution);

	static float size_width[1] = { 5.0f };
	glUniform1fv(Unif_width, 1, size_width);

	glBegin(GL_TRIANGLES);

	glVertex2f(0.0f, 0.3f);
	glVertex2f(0.3f, -0.3f);
	glVertex2f(-0.3f, -0.3f);

	glEnd();


	glFlush();
	glUseProgram(0);
	checkOpenGLerror();
	glutSwapBuffers();
}

void init()
{
	glClearColor(0, 0, 0, 0);
}

void specialKeys(int key, int x, int y)
{
	switch (key) {
	case GLUT_KEY_F1:
		flag = 0;               
		break;
	case GLUT_KEY_F2:
		flag = 1;
		break;
	case GLUT_KEY_F3:
		flag = 2;
		break;
	case GLUT_KEY_F4:
		flag = 3;
		break;
	case GLUT_KEY_F5:
		flag = 4;
		break;
	case GLUT_KEY_F6:
		flag = 5;
		break;
	

	case GLUT_KEY_UP:
		verflag = 0;
		break;
	
	case GLUT_KEY_DOWN:
		verflag = 1;
		break;

	case GLUT_KEY_LEFT:
		verflag = 2;
		break;

	case GLUT_KEY_RIGHT:
		verflag = 3;
		break;
	}

	initShader();
	glutPostRedisplay();
}

void keyboardHandler(unsigned char key, int x, int y)
{
	switch (verflag)
	{
	case 0:
		switch (key)
		{
		case 'd':
			scaleX[0] += 0.5f;
			break;
		case 'a':
			scaleX[0] -= 0.5f;
			break;
		}
	case 1:
		switch (key)
		{
		case 'd':
			scaleY[1] += 0.5f;
			break;
		case 'a':
			scaleY[1] -= 0.5f;
			break;
		}
	case 2:
		switch (key)
		{
		case 'd':
			angle[0] += 0.5f;
			break;
		case 'a':
			angle[0] -= 0.5f;
			break;
		}
	case 3:
		switch (key)
		{
		case 'd':
			transport[0] += 0.5f;
			break;
		case 'a':
			transport[0] -= 0.5f;
			break;
		case 'w':
			transport[1] += 0.5f;
			break;
		case 'x':
			transport[1] -= 0.5f;
			break;

		}

	}

	initShader();
	glutPostRedisplay();
}

int main(int argc, char **argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_RGBA | GLUT_ALPHA | GLUT_DOUBLE);
	glutInitWindowSize(800, 600);
	glutCreateWindow(" lab 12 ");

	auto glew_status = glewInit();
	if (GLEW_OK != glew_status)
	{
		std::cout << "Error: " << glewGetErrorString(glew_status) << "\n";
		return 1;
	}

	init();
	initShader();

	glutKeyboardFunc(keyboardHandler);
	glutSpecialFunc(specialKeys);
	glutReshapeFunc(resizeWindow);
	glutDisplayFunc(render);
	glutMainLoop();

	freeShader();
}
