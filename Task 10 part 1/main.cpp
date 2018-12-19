#include "glew.h"
#include "freeglut.h"
#include "figures.h"
#include <iostream>

typedef void(*Function) (void);

int n = 0;
const int primitivesCount = 8;
const Function primitives[primitivesCount] =
{
	teapot,
	cube,
	sphere,
	torus,      
	icosahedron,
	
	rect,
	triangle2,
	triangle
};

//углы поворота 
float rotate_x = 0;
float rotate_y = 0;
float rotate_z = 0;

float r = 0, g = 0, b = 0;

void setRandomColor()
{
	r = (rand() % 255) / 255.0;
	g = (rand() % 255) / 255.0;
	b = (rand() % 255) / 255.0;
}

//получение изображения
void render()
{

	//очистка буфферов
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glClearColor(0.23, 0.23, 0.23, 1.0);

	//вращение вокруг осей(повороты)
	glRotatef(rotate_x, 1, 0, 0);
	glRotatef(rotate_y, 0, 1, 0);
	glRotatef(rotate_z, 0, 0, 1);

	//установка цвета
	glColor3f(r, g, b);
	primitives[n]();

	glLoadIdentity();//считывает текущую матрицу
	glutSwapBuffers();
}

void mouseHandler(int button, int state, int x, int y)
{
	if (button == GLUT_LEFT_BUTTON && state == GLUT_DOWN)
	{
		setRandomColor();
		n = rand() % primitivesCount;
	}
}

void keyHandler(int key, int x, int y)
{
	switch (key)
	{
	case GLUT_KEY_UP: rotate_x += 5; break;
	case GLUT_KEY_DOWN: rotate_x -= 5; break;
	case GLUT_KEY_LEFT: rotate_y += 5; break;
	case GLUT_KEY_RIGHT: rotate_y -= 5; break;
	case GLUT_KEY_PAGE_UP: rotate_z += 5; break;
	case GLUT_KEY_PAGE_DOWN: rotate_z -= 5; break;
	default:
		break;
	}
	//вызывает функцию перерисовки
	glutPostRedisplay();
}


int main(int argc, char** argv)
{

	glutInit(&argc, argv); //Инициализация  аргументами
	glutInitDisplayMode(GLUT_DEPTH | GLUT_DOUBLE | GLUT_RGBA);//устанавливаем для окна режим отображения информации
	glutInitWindowPosition(20, 20); //задать положение создаваемого окна относительно верхнего левого угла экрана
	glutInitWindowSize(800, 600); //размер окна
	glutCreateWindow("OpenGL Window");//создаёт окно с заголовком, который вы укажете в качестве параметр

	glEnable(GL_DEPTH_TEST); //Буффер глубины включается

	glutDisplayFunc(render); // вызываем функцию, отвечающую за рисование
	glutMouseFunc(mouseHandler);// -//- за кликание мышкой
	glutSpecialFunc(keyHandler);// -//- за нажатие клавиш


	/* Вход в главный цикл GLUT.

	Ну и последнее, что необходимо сделать, чтобы запустить нашу программу 
	- это войти в так называемый главный цикл GLUT. 
	Этот цикл запускает на выполнение так называемое сердце GLUT, 
	которое обеспечивает взаимосвязь между операционной системой 
	и теми функциями, которые отвечают за окно, получают 
	информацию от устройств ввода/вывода.
	Для того, чтобы перейти в главный цикл GLUT, 
	надо выполнить единственную команду:*/
	glutMainLoop();

	return 0;
}