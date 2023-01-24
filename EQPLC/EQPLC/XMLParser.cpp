#include "StdAfx.h"
#include "xmlparser.h"

CXMLParser::CXMLParser(void)
{
}

CXMLParser::~CXMLParser(void)
{
}

const CString CXMLParser::GetText(CString sBody, CString sTag)
{
	int	nStart = sBody.Find(_T("<")+sTag);		// finding <Tag
	if(nStart == -1)
		return _T("");
	nStart = sBody.Find(_T(">"), nStart+1);		// finding <Tag ...>
	int	nEnd = sBody.Find(_T("</")+sTag, nStart+1);	// finding </Tag>

	if (nStart == -1 || nEnd == -1) 
		return _T("");
	else
		return sBody.Mid(nStart+1, nEnd-nStart-1);
}

const CString CXMLParser::GetAttribute(CString sBody, CString sTag)
{
	int nStart = sBody.Find(sTag+_T("=\""));
	if (nStart == -1) return _T("");

	if (nStart+ sTag.GetLength() > sBody.GetLength()) return _T("");

	int nEnd  = sBody.Find(_T("\""), nStart+sTag.GetLength()+2);
	if (nEnd == -1) return _T("");

	return sBody.Mid(nStart+sTag.GetLength()+2, nEnd-nStart-sTag.GetLength()-2);
}

const CString CXMLParser::GetElement(CString sBody, CString sTag)
{
	int nStart = sBody.Find(_T("<")+sTag+_T(">"));
	int nEnd = sBody.Find(_T("</")+sTag+_T(">"), nStart+1);

	if(nStart==-1 || nEnd==-1)	return _T("");
	
	return sBody.Mid(nStart, nEnd+sTag.GetLength()+3-nStart);
}

bool CXMLParser::GetElements(CString sBody, CString sTag, CStringArray &srgItems)
{
	int i=0;
	int nStart = 0;
	int nEnd = 0;

	do{
		nStart = sBody.Find(_T("<")+sTag+_T(">"), nStart);
		nEnd = sBody.Find(_T("</")+sTag+_T(">"), nStart+1);

		if(nStart==-1 || nEnd==-1)	break;

		CString sTemp = sBody.Mid(nStart, nEnd+sTag.GetLength()+3-nStart);
		srgItems.Add(sTemp);

		nStart = nEnd+1;
	} while( nStart!=-1 || nEnd!=-1);

	return true;
}

std::vector<CString> CXMLParser::GetTexts(CString sBody, CString sTag)
{
	std::vector<CString> vecText;
	CString fullText = sBody;
	int nEnd = 0;

	CString text = GetText(fullText, sTag);
	while(!text.IsEmpty())
	{
		vecText.push_back(text);
		nEnd = fullText.Find(_T("</")+sTag, 0);	// finding </Tag>
		fullText = fullText.Mid(nEnd+1);
		text = GetText(fullText, sTag);
	}	

	return vecText;
}
