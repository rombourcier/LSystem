#pragma once
#include <iostream>
#include <functional>
class Rules
{
protected:
	char m_entry;
	std::string m_out;
	std::function<void()> m_To_Call = nullptr;
	Rules();
public:

	Rules(char _entry, std::string _out, std::function<void()> ToCall);
	char GetEntry();
	std::string GetNextStr();
	void ApplyRules();
};

