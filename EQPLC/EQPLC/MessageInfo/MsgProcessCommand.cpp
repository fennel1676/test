#include "StdAfx.h"
#include "MsgProcessCommand.h"
#include "../XMLParser.h"

using namespace Message;

CMsgProcessCommand::CMsgProcessCommand(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 14;

	nPortNo = 0;
	nCommandID = 0;
	strCassetteID = "";
	nMapStif = 0;
	nStartStif = 0;
	nByWho = 0;
}

CMsgProcessCommand::~CMsgProcessCommand(void)
{
}

bool CMsgProcessCommand::ParseMsg(const CString& strXML) 
{ 
	CString strBuf;
	CString strInfo;

	strInfo = CXMLParser::GetElement(strXML, _T("INFO"));

	strBuf = CXMLParser::GetText(strInfo, _T("PORT"));
	nPortNo = atoi(strBuf);

	strBuf = CXMLParser::GetText(strInfo, _T("ID"));
	nCommandID = atoi(strBuf);

	strCassetteID = CXMLParser::GetText(strInfo, _T("CSTID"));

	strBuf = CXMLParser::GetText(strInfo, _T("MAT_STIF"));
	nMapStif = atoi(strBuf);

	strBuf = CXMLParser::GetText(strInfo, _T("START_STIF"));
	nStartStif = atoi(strBuf);


	strBuf = CXMLParser::GetText(strInfo, _T("BYWHO"));
	nByWho = atoi(strBuf);

	return true; 
}