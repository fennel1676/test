#include "StdAfx.h"
#include "MsgEQOnlineParameterCommand.h"
#include "../XMLParser.h"

using namespace Message;

CMsgEQOnlineParameterCommand::CMsgEQOnlineParameterCommand(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 7;

	nCommandID = 0;
	nJudgement = 0;
	nVCRMode = 0;
	nWaitTime = 0;
	nWIPQTY = 0;
	nByWho = 0;
}

CMsgEQOnlineParameterCommand::~CMsgEQOnlineParameterCommand(void)
{

}


bool CMsgEQOnlineParameterCommand::ParseMsg(const CString& strXML) 
{
	CString strBuf;
	strBuf = CXMLParser::GetText(strXML, _T("ID"));
	nCommandID = atoi(strBuf);

	strBuf = CXMLParser::GetText(strXML, _T("JUDGEMENT"));
	nJudgement = atoi(strBuf);

	strBuf = CXMLParser::GetText(strXML, _T("VCR"));
	nVCRMode = atoi(strBuf);

	strBuf = CXMLParser::GetText(strXML, _T("WAIT"));
	nWaitTime = atoi(strBuf);

	strBuf = CXMLParser::GetText(strXML, _T("MODE"));
	nWIPQTY = atoi(strBuf);

	strBuf = CXMLParser::GetText(strXML, _T("BYWHO"));
	nByWho = atoi(strBuf);
	return true;
}