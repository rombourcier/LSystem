// JeuxDeLaVie.cpp : Ce fichier contient la fonction 'main'. L'exécution du programme commence et se termine à cet endroit.
//

#include <iostream>
#include"Rules.h"
#include "LSystem.h"

void ARule()
{
	std::cout << "Rule";
}
int main()
{

	char* Input_Rules = new char();
	int nb_Iterration = 0;
	LSystem *lSystem = new LSystem();
	std::cout << "Give Starting states of your LSystem : ";
	std::cin >> Input_Rules;
	std::cout << std::endl << "Give Itteration Of your LSystem : ";
	std::cin >> nb_Iterration;
	lSystem->CallSystem(Input_Rules, nb_Iterration);
}

// Exécuter le programme : Ctrl+F5 ou menu Déboguer > Exécuter sans débogage
// Déboguer le programme : F5 ou menu Déboguer > Démarrer le débogage

// Astuces pour bien démarrer : 
//   1. Utilisez la fenêtre Explorateur de solutions pour ajouter des fichiers et les gérer.
//   2. Utilisez la fenêtre Team Explorer pour vous connecter au contrôle de code source.
//   3. Utilisez la fenêtre Sortie pour voir la sortie de la génération et d'autres messages.
//   4. Utilisez la fenêtre Liste d'erreurs pour voir les erreurs.
//   5. Accédez à Projet > Ajouter un nouvel élément pour créer des fichiers de code, ou à Projet > Ajouter un élément existant pour ajouter des fichiers de code existants au projet.
//   6. Pour rouvrir ce projet plus tard, accédez à Fichier > Ouvrir > Projet et sélectionnez le fichier .sln.
