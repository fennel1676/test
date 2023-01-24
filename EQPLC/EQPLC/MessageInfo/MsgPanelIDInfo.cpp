#include "StdAfx.h"
#include "MsgPanelIDInfo.h"
#include "../XMLParser.h"

using namespace Message;

CMsgPanelIDInfo::CMsgPanelIDInfo(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 16;

	nPortNo = 0;
	strHPanelID="";
	strUniqueID="";
}

CMsgPanelIDInfo::~CMsgPanelIDInfo(void)
{
}

bool CMsgPanelIDInfo::ParseMsg(const CString& strXML) 
{ 
	CString strBuf;
	CString strInfo;
	int nEndIndex = 0;
	int nStartIndex = 0;
	CString str = "";

	strInfo = CXMLParser::GetElement(strXML, _T("INFO"));

	strBuf = CXMLParser::GetText(strInfo, _T("PORT"));
	nPortNo = atoi(strBuf);

	strHPanelID = CXMLParser::GetText(strInfo, _T("HPANELID"));

	strUniqueID = CXMLParser::GetText(strInfo, _T("UNIQUEID"));

	// 길이 잘라 값 가져오기
	nEndIndex = strUniqueID.Find(" ",0);
	for(int i=0; i< 4; i++)
	{
		for(int j=nStartIndex; j<nEndIndex; j++)
		{
			str += strUniqueID[j];
		}
		nStartIndex = nEndIndex+1;
		nEndIndex = strUniqueID.Find(" ",nStartIndex);
		if(nEndIndex == -1)
		{
			nEndIndex = strlen(strUniqueID);
		}
		nUniqueID[i] = atoi(str);
		str="";
	}
	return true; 
}