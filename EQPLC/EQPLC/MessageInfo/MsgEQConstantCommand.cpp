#include "StdAfx.h"
#include "MsgEQConstantCommand.h"
#include "../XMLParser.h"

using namespace Message;

CMsgEQConstantCommand::CMsgEQConstantCommand(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 10;
	
	memset(stECIDInfo, 0x00, sizeof(CMsgEQConstantCommand::ECID_INFO) * 15);
}

CMsgEQConstantCommand::~CMsgEQConstantCommand(void)
{

}

bool CMsgEQConstantCommand::ParseMsg(const CString& strXML) 
{
	CString strBuf;
	CString strInfo;

	strInfo = CXMLParser::GetElement(strXML, _T("INFO"));

	strBuf = CXMLParser::GetText(strInfo, _T("ID"));
	nCommandID = atoi(strBuf);

	std::vector<CString> vtFlow = CXMLParser::GetTexts(strInfo, _T("DATA"));

	for(int i = 0; i < vtFlow.size(); i++)
	{
		strBuf = CXMLParser::GetText(vtFlow[i], _T("ECID"));
		stECIDInfo[i].nECID = atoi(strBuf);

		strBuf = CXMLParser::GetText(vtFlow[i], _T("ECDEF"));
		stECIDInfo[i].nECDEF = atoi(strBuf);

		strBuf = CXMLParser::GetText(vtFlow[i], _T("ECSLL"));
		stECIDInfo[i].nECSLL = atoi(strBuf);

		strBuf = CXMLParser::GetText(vtFlow[i], _T("ECSUL"));
		stECIDInfo[i].nECSUL = atoi(strBuf);

		strBuf = CXMLParser::GetText(vtFlow[i], _T("ECWLL"));
		stECIDInfo[i].nECWLL = atoi(strBuf);

		strBuf = CXMLParser::GetText(vtFlow[i], _T("ECWUL"));
		stECIDInfo[i].nECWUL = atoi(strBuf);
	}
	return true;
}