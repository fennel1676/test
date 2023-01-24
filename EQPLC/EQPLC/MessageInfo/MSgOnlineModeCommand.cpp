#include "StdAfx.h"
#include "MSgOnlineModeCommand.h"
#include "../XMLParser.h"

using namespace Message;

CMSgOnlineModeCommand::CMSgOnlineModeCommand(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 13;

	nID=0;

}

CMSgOnlineModeCommand::~CMSgOnlineModeCommand(void)
{
}

bool CMSgOnlineModeCommand::ParseMsg(const CString& strXML) 
{ 
	CString strBuf;
	CString strInfo;

	strInfo = CXMLParser::GetElement(strXML, _T("INFO"));

	strBuf = CXMLParser::GetText(strInfo, _T("ID"));
	nID = atoi(strBuf);
	return true; 
}