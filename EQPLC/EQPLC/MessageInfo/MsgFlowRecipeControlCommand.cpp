#include "StdAfx.h"
#include "MsgFlowRecipeControlCommand.h"
#include "../XMLParser.h"

using namespace Message;

CMsgFlowRecipeControlCommand::CMsgFlowRecipeControlCommand(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 3;

	nCommandID = 0;
	nFlowNo = 0;
	nRevision = 0;
	memset(nBody, 0x00, sizeof(short) * 10);
}

CMsgFlowRecipeControlCommand::~CMsgFlowRecipeControlCommand(void)
{
}

bool CMsgFlowRecipeControlCommand::ParseMsg(const CString& strXML) 
{ 
	CString strBuf;
	CString strInfo;

	strInfo = CXMLParser::GetElement(strXML, _T("INFO"));

	strBuf = CXMLParser::GetText(strInfo, _T("COMMAND"));
	nCommandID = atoi(strBuf);

	strBuf = CXMLParser::GetText(strInfo, _T("NO"));
	nFlowNo = atoi(strBuf);

	strFlowID = CXMLParser::GetText(strInfo, _T("ID"));

	strBuf = CXMLParser::GetText(strInfo, _T("REVISION"));
	nRevision = atoi(strBuf);

	strTime = CXMLParser::GetText(strInfo, _T("TIME"));

	CString strBody = CXMLParser::GetText(strInfo, _T("BODY"));
	for(int i = 0; i < 10; i++)
	{
		AfxExtractSubString(strBuf, strBody, i, ' ');
		nBody[i] = atoi(strBuf);
	}

	return true; 
}