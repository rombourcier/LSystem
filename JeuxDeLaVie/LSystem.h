#pragma once
#include "Rules.h"
#include <vector>

class LSystem
{
	std::vector<Rules*>* All_Rules;
	void Init();
	void AddRules();
	std::string m_str;

#pragma region RulesApplication
	void AddCircle();
	void AddLetter();
	void Rotate();
#pragma endregion

	std::string m_Next_Value(char _current);
	std::string m_Next_Iterration(std::string _enter);

	void LoadSystem(std::string _start, int Iterration);
	void CallRule(char _charRules);
public:
	void CallSystem(std::string _start,int Iterration);
	LSystem();
};

