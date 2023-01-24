#include "StdAfx.h"
#include "MsgEquipmentCommand.h"
#include "../XMLParser.h"

using namespace Message;

CMsgEquipmentCommand::CMsgEquipmentCommand(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 2;

	nCommandID = 0;
	nNum = 0;
	nByWho = 0;
}

CMsgEquipmentCommand::~CMsgEquipmentCommand(void)
{
}

bool CMsgEquipmentCommand::ParseMsg(const CString& strXML) 
{ 
	CString strBuf;
	CString strInfo;

	strInfo = CXMLParser::GetElement(strXML, _T("INFO"));
	
	strBuf = CXMLParser::GetText(strInfo, _T("COMMAND"));
	nCommandID = atoi(strBuf);

	strCode = CXMLParser::GetText(strInfo, _T("CODE"));
	
	strBuf = CXMLParser::GetText(strInfo, _T("NUM"));
	nNum = atoi(strBuf);
	
	strTerminal = CXMLParser::GetText(strInfo, _T("TERMINAL"));	
	strOPCall = CXMLParser::GetText(strInfo, _T("OPCALL"));
	
	strBuf = CXMLParser::GetText(strInfo, _T("BYWHO"));
	nByWho = atoi(strBuf);
	
	return true; 
}