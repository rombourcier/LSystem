#include "Rules.h"


char Rules::GetEntry()
{
	return m_entry;
}

Rules::Rules()
{
}

Rules::Rules(char _entry, std::string _out, std::function<void()> ToCall)
{
	m_entry = _entry;
	m_out = _out;
	m_To_Call = ToCall;
}

std::string Rules::GetNextStr()
{
	return m_out;
}

void Rules::ApplyRules()
{
	m_To_Call();
}
