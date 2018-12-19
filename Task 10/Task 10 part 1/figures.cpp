#include "figures.h"

void triangle()
{
	glBegin(GL_TRIANGLES);
	glVertex2f(0, -0.9);
	glVertex2f(0.4, 0.9);
	glVertex2f(0.9, 0.6);
	glEnd();

}
void triangle2()
{
	glBegin(GL_TRIANGLES);
	glColor3f(1.f, 0.f, 0.f);
	glVertex2f(-0.5f, -0.5f);
	glColor3f(0.f, 1.f, 0.f);
	glVertex2f(0.f, 0.5f);
	glColor3f(0.f, 0.f, 1.f);
	glVertex2f(0.5f, -0.5f);
	glEnd();
}
void rect()
{
	glBegin(GL_QUADS);
	glVertex2f(0.2, 0.4);
	glVertex2f(0.8, -0.1);
	glVertex2f(-0.5, -0.346);
	glVertex2f(-0.4, 0.6);
	glEnd();
}
/*void square()
{
	glBegin(GL_QUADS);
	glColor3f(0.52, 0.44, 0.33);
	glVertex2f(0.9, 0.9);
	glVertex2f(0.9, -0.9);
	glVertex2f(-0.9, -0.9);
	glVertex2f(-0.9, 0.9);
	glEnd();
}*/
void teapot()
{
	glutWireTeapot(0.55);
}
void cube()
{
	glutWireCube(0.55);
}
void sphere()
{
	glutWireSphere(0.55, 20, 20);
}
void torus()
{
	glutWireTorus(0.4, 0.6, 20, 20);
}
void icosahedron()
{
	glutWireIcosahedron();
}
