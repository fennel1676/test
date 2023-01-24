#include "StdAfx.h"
#include "XMLMsg.h"
#include "XMLParser.h"
#include "MessageInfo.h"

CXMLMsg::CXMLMsg() : m_pInfo(NULL)
{
}

CXMLMsg::~CXMLMsg(void)
{
	delete m_pInfo;
	m_pInfo = NULL;
}

int CXMLMsg::GetMessageType() const		
{ 
	return NULL == m_pInfo ? 0 : m_pInfo->GetMessageType(); 
}

int CXMLMsg::GetMessageCommand()	const	
{ 
	int a = m_pInfo->GetMessageCommand();
	return NULL == m_pInfo ? 0 : m_pInfo->GetMessageCommand(); 
}

CString CXMLMsg::GetDoc()
{
	if(NULL == m_pInfo)
		return _T("");

	CString strHeader = GetHeader();
	CString strBody = m_pInfo->GetMsg();
	if(strHeader.IsEmpty() || strBody.IsEmpty())
		return _T("");

	return CString(_T("<MSG>")) + strHeader + strBody + CString(_T("</MSG>"));
}

const CString CXMLMsg::GetHeader()
{
	if(m_strSourceEquipment.IsEmpty() || m_strSourceUnit.IsEmpty()
		|| m_strDestinationEquipment.IsEmpty() || m_strDestinationUnit.IsEmpty()
		|| GetMessageTypeString().IsEmpty())
	{
		return _T("");
	}

	CString strHeaderString;
	strHeaderString.Format(
		_T("<TARGET>") 
			_T("<SOURCE>")
				_T("<EQUIPMENT>%s</EQUIPMENT>")
				_T("<UNIT>%s</UNIT>")
			_T("</SOURCE>")
			_T("<DESTINATION>")
				_T("<EQUIPMENT>%s</EQUIPMENT>")
				_T("<UNIT>%s</UNIT>")
			_T("</DESTINATION>")
		_T("</TARGET>")
		_T("<CMD>")
			_T("<TYPE>%s</TYPE>")
			_T("<COMMAND>%d</COMMAND>")
		_T("</CMD>"),
			m_strSourceEquipment, m_strSourceUnit, m_strDestinationEquipment, m_strDestinationUnit,
			GetMessageTypeString(), GetMessageCommand()
	);

	return strHeaderString;
}

void CXMLMsg::SetSource(const CString& strEquipment, const CString& strUnit)
{
	m_strSourceEquipment = strEquipment;
	m_strSourceUnit = strUnit;
}

void CXMLMsg::SetDestination(const CString& strEquipment, const CString& strUnit)
{
	m_strDestinationEquipment = strEquipment;
	m_strDestinationUnit = strUnit;
}

void CXMLMsg::GetSource(CString &strEquipment, CString &strUnit)
{
	strEquipment = m_strSourceEquipment;
	strUnit = m_strSourceUnit;
}

void CXMLMsg::GetDestination(CString &strEquipment, CString &strUnit)
{
	strEquipment = m_strDestinationEquipment;
	strUnit = m_strDestinationUnit;
}

int CXMLMsg::Load(IMessageInfo *pMessageInfo)
{
	if(NULL == pMessageInfo)
		return 1;

	SetDestination(_T("LC"), _T("N/A"));
	
	delete m_pInfo; //혹시 다른 포인터를 가지고 있었다면 메모리 해제

	m_pInfo = pMessageInfo;
	return 0;
}

int CXMLMsg::Load(const CString& strXML)
{
	int nCommand = GetCommandFromXML(strXML);
	int nMessageType = GetMessageTypeFromXML(strXML);

	if(1 == nMessageType && ParseHeader(strXML))
	{
		delete m_pInfo; //혹시 다른 포인터를 가지고 있었다면 메모리 해제
		m_pInfo = IMessageInfo::CreateInfo(nCommand);
		if(NULL != m_pInfo && m_pInfo->ParseMsg(strXML))
		{
			return 0;
		}		
		delete m_pInfo; m_pInfo = NULL; //memory 생성 또는 parsing에 실패한 경우이므로 메모리 해제
		return 1;
	}
	return 2;
}

bool CXMLMsg::ParseHeader(const CString& strXML)
{
	CString temp = CXMLParser::GetElement(strXML, _T("SOURCE"));
	if(!temp.IsEmpty())
	{
		m_strSourceEquipment = CXMLParser::GetText(temp, _T("EQUIPMENT"));
		m_strSourceUnit = CXMLParser::GetText(temp, _T("UNIT"));

		temp = CXMLParser::GetElement(strXML, _T("DESTINATION"));
		if(!temp.IsEmpty())
		{
			m_strDestinationEquipment = CXMLParser::GetText(temp, _T("EQUIPMENT"));
			m_strDestinationUnit = CXMLParser::GetText(temp, _T("UNIT"));
		}
		else
		{
			//실패한 경우 Source값들도 의미 없으므로 지운다.
			m_strSourceEquipment.Empty();
			m_strSourceUnit.Empty();
		}
	}
	return temp.IsEmpty() == FALSE;
}


const CString CXMLMsg::GetMessageTypeString()
{
	CString strBuf;
	switch(GetMessageType())
	{
	case 1:	strBuf = _T("COMMAND");	break;
	case 2:	strBuf = _T("EVENT");		break;
	case 3:	strBuf = _T("REPORT");		break;
	}
	return strBuf;
}

int CXMLMsg::GetCommandFromXML(const CString& strXML)
{
	return _tcstol(CXMLParser::GetText(strXML, _T("COMMAND")), NULL, 10);
}

int CXMLMsg::GetMessageTypeFromXML(const CString& strXML)
{
	CString strType = CXMLParser::GetText(strXML, _T("TYPE"));

	int nType = 0;
	if(strType == _T("COMMAND"))
	{
		nType = 1;
	}
	else if(strType == _T("EVENT"))
	{
		nType = 2;
	}
	else if(strType == _T("REPORT"))
	{
		nType = 3;
	}
	return nType;
}


