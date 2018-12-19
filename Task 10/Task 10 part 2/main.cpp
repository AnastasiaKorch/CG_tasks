#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include "glew.h"
#include "freeglut.h"

enum RotationMode { AROUND_CENTER_SCREEN, AROUND_CENTER_SELF, AROUND_FIRST_PLACE, MIXED };

static int win_width, win_height;

int num = 0;
static float rotate_x = 0.0, rotate_y = 0.0, rotate_z = 0.0;
static RotationMode rotation_mode = MIXED;
static bool rotate = false;
static bool is_perpective = true;

GLfloat camX = 0.0, camY = 0.0, camZ = -5.0;

// позиция пьедестала
GLfloat _x = 0.6, _y = 0.3, _z = 0.0;

void rotateAllAxis()
{
	glRotatef(rotate_x, 1.0, 0.0, 0.0);
	glRotatef(rotate_y, 0.0, 1.0, 0.0);
	glRotatef(rotate_z, 0.0, 0.0, 1.0);
}

void applyRotationMode(GLfloat pos_x, GLfloat pos_y, GLfloat pos_z)
{
	switch (rotation_mode)
	{
	case RotationMode::AROUND_CENTER_SCREEN:
		glTranslatef(-pos_x, -pos_y, -pos_z);
		rotateAllAxis();
		glTranslatef(pos_x, pos_y, pos_z);
		break;
	case RotationMode::AROUND_FIRST_PLACE:
		// где pos_x, pos_y, pos_z - это позиция пьедестала первого места
		glTranslatef(_x - pos_x, _y - pos_y, _z - pos_z);
		rotateAllAxis();
		glTranslatef(-(_x - pos_x), -(_y - pos_y), -(_z - pos_z));
		break;
	case RotationMode::AROUND_CENTER_SELF:
		rotateAllAxis();
		break;
	case RotationMode::MIXED:
		glTranslatef(_x - pos_x, _y - pos_y, _z - pos_z);
		rotateAllAxis();
		glTranslatef(-(_x - pos_x), -(_y - pos_y), -(_z - pos_z));
		rotateAllAxis();
		break;
	default:
		break;
	}

}

void drawAxis()
{
	glPushMatrix();
	glScalef(0.75f, 0.75f, 0.75f);
	glBegin(GL_LINES);

	glColor3f(1.0f, 0.0f, 0.0f);
	glVertex3f(0.0f, 0.0f, 0.0f);
	glVertex3f(3.0f, 0.0f, 0.0f);

	glColor3f(0.0f, 1.0f, 0.0f);
	glVertex3f(0.0f, 0.0f, 0.0f);
	glVertex3f(0.0f, 3.0f, 0.0f);

	glColor3f(0.0f, 0.0f, 1.0f);
	glVertex3f(0.0f, 0.0f, 0.0f);
	glVertex3f(-0.2f, -0.1f, 3.0f);
	glEnd();
	glPopMatrix();
}

void resize(int w, int h)
{
	win_width = w;
	win_height = h;
	glClearColor(0.5, 0.5, 0.5, 1.0);
	glViewport(0, 0, win_width, win_height);

	if (win_height == 0) win_height = 1;                // To prevent divide by 0
	GLfloat aspect = (GLfloat)win_width / (GLfloat)win_height;

	// Set the aspect ratio of the clipping area to match the viewport
	glMatrixMode(GL_PROJECTION);  // To operate on the Projection matrix
	glLoadIdentity();             // Reset the projection matrix
}

void firstPlaceCube()
{
	GLfloat x = _x, y = _y, z = _z;
	glColor3f(1.0, 215 / 255.0, 0.0);
	glPushMatrix();
	glMatrixMode(GL_MODELVIEW);
	glTranslatef(x, y, z);
	applyRotationMode(x, y, z);
	glutSolidCube(0.6);
	glPopMatrix();
}

void secondPlaceCube()
{
	GLfloat x, y, z;
	x = 0.1;
	y = .2;
	z = .1;
	
	glColor3f(192.0 / 255.0, 192.0 / 255.0, 192.0 / 255.0);
	glPushMatrix();
	glMatrixMode(GL_MODELVIEW);
	glTranslatef(x, y, z);
	applyRotationMode(x, y, z);
	glutSolidCube(0.4);
	glPopMatrix();
}

void thirdPlaceCube()
{
	GLfloat x, y, z;
	x = 1.05;
	y = 0.15;
	z = 0.15;
	glColor3f(205.0 / 255.0, 127.0 / 255.0, 50.0 / 255.0);
	glPushMatrix();
	glMatrixMode(GL_MODELVIEW);
	glTranslatef(x, y, z);
	applyRotationMode(x, y, z);
	glutSolidCube(0.3);
	glPopMatrix();
}

void keyboardHandler(unsigned char key, int x, int y)
{
	switch (key)
	{
	case 'c':rotation_mode = RotationMode::AROUND_CENTER_SCREEN;
		break;
	case 'f':rotation_mode = RotationMode::AROUND_FIRST_PLACE;
		break;
	case 's':rotation_mode = RotationMode::AROUND_CENTER_SELF;
		break;
	case 'd':rotation_mode = RotationMode::MIXED;
		break;
	case 'r': rotate = !rotate;
		break;
	case 'p': is_perpective = !is_perpective;
		break;
	default:
		break;
	}
}

void specialKeyboardHandler(int key, int x, int y)
{
	switch (key)
	{
	case GLUT_KEY_DOWN: camZ++; break;
	case GLUT_KEY_UP: camZ--; break;
	case GLUT_KEY_RIGHT: camY--; break;
	case GLUT_KEY_LEFT: camY++; break;
	case GLUT_KEY_PAGE_UP: camX++; break;
	case GLUT_KEY_PAGE_DOWN: camX--; break;

	default: break;
	}
}

void update()
{

	glLoadIdentity();
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glClearColor(0.5, 0.5, 0.5, 1.0);

	//-----------------------
	/*glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(50.0, win_width / win_height, 1.0, 35.0);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();*/
	//--------------------------

	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();

	if (is_perpective)
	{
		//gluPerspective(50.0, win_width / win_height, 1.0, 35.0);
		gluPerspective(65.f, (float)win_width / win_height, 1.f, 1000.f);
		//gluLookAt(0., 2., 2., 0., 0., 0., 0., 1., 0.);
		gluLookAt(0., 0., 2., 0., 0., 0., 0., 1., 0.);
	}
	else
	{
		glOrtho(-2.f, 2.f, -2.f, 2.f, -2.f, 2.f);
	}

	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();

	glTranslatef(0.0, 0.0, camZ);//перемещение камеры

	glRotatef(10.0, 1.0, 0.0, 0.0);
	glRotatef(camY, 0.0, 1.0, 0.0);
	glRotatef(camX, 1.0, 0.0, 0.0);

	// если анимируется поворот фигур
	if (rotate)
	{
		rotate_y += 0.01;
	}

	firstPlaceCube();//золотой
	secondPlaceCube(); //серебрянный
	thirdPlaceCube(); // бронзовый
	drawAxis();

	glFlush();
	glutSwapBuffers();
}

int main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_DOUBLE | GLUT_RGBA);
	glutInitWindowSize(600, 600);
	glutInitWindowPosition(20, 20);
	glutCreateWindow("OpenGL Window");

	glEnable(GL_DEPTH_TEST);
	glEnable(GL_TEXTURE_2D);

	glutIdleFunc(update);
	glutDisplayFunc(update);
	glutReshapeFunc(resize);//изменение окна

	// обработчик нажатий букв
	glutKeyboardFunc(keyboardHandler);
	// обработчик нажатий спец символов
	glutSpecialFunc(specialKeyboardHandler);

	glutMainLoop();
	return 0;
}