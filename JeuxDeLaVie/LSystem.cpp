#include "LSystem.h"

void LSystem::Init()
{
	All_Rules = new std::vector<Rules*>();
	AddRules();
}

// This is the place where you can AddRules
void LSystem::AddRules()
{
	using std::placeholders::_1;
	std::function<void()> ToPush = std::bind(&LSystem::AddLetter, this);
	All_Rules->push_back(new Rules('O', "OXO", ToPush));

	ToPush = std::bind(&LSystem::AddCircle, this);
	All_Rules->push_back(new Rules('X', "OX+O", ToPush));

	ToPush = std::bind(&LSystem::Rotate, this);
	All_Rules->push_back(new Rules('+', "+", ToPush));
}

void LSystem::AddCircle()
{
	std::cout << "O ";
}

void LSystem::AddLetter()
{
	std::cout << "X ";
}

void LSystem::Rotate()
{
	std::cout << "\n  ";
}

std::string LSystem::m_Next_Value(char _current)
{
	for (int i = 0; i < All_Rules->size(); ++i)
	{
		if (All_Rules->at(i)->GetEntry() == _current)
			return All_Rules->at(i)->GetNextStr();
	}
	return std::string();
}

std::string LSystem::m_Next_Iterration(std::string _enter)
{
	std::string _out;
	for (int i = 0; i < _enter.size(); ++i)
	{
		_out += m_Next_Value(_enter[i]);
	}
	return _out;
}

void LSystem::LoadSystem(std::string _start, int Iterration)
{
	m_str = _start;
	std::string current;
	for (int i = 0; i < Iterration; ++i)
	{
		current = m_Next_Iterration(m_str);
		m_str = current;
	}
}

void LSystem::CallRule(char _charRules)
{
	for (int i = 0; i < All_Rules->size(); ++i)
	{
		if (All_Rules->at(i)->GetEntry() == _charRules)
			All_Rules->at(i)->ApplyRules();
	}
}


void LSystem::CallSystem(std::string _start,int Iterration)
{
	LoadSystem(_start, Iterration);
	for (int i = 0; i < m_str.size(); i++)
	{
		CallRule(m_str[i]);
	}
	
}


LSystem::LSystem()
{
	Init();
}
