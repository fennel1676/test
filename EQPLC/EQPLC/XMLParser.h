#pragma once

#include <vector>

class CXMLParser
{
public:
	CXMLParser(void);
	~CXMLParser(void);

	static const CString GetText(CString sBody, CString sTag);

	static const CString GetElement(CString sBody, CString sTag);
	static bool	GetElements(CString sBody, CString sTag, CStringArray &srgItems);

	static const CString GetAttribute(CString sBody, CString sTag);
	static std::vector<CString> GetTexts(CString sBody, CString sTag);
};
