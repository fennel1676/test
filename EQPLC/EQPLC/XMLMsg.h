#pragma once

interface IMessageInfo;

class CXMLMsg
{
public:
	CXMLMsg(void);
	~CXMLMsg(void);
public:
	CString GetDoc();
	int GetMessageType() const;
	int GetMessageCommand()	const;

	void SetSource(const CString& strEquipment, const CString& strUnit);
	void SetDestination(const CString& strEquipment, const CString& strUnit);
	void GetSource(CString &strEquipment, CString &strUnit);
	void GetDestination(CString &strEquipment, CString &strUnit);

	//이 Method를 통해 받아간 Pointer를 delete해서는 안된다.
	IMessageInfo* GetInfo() { return m_pInfo; }
public:
	//이 Method를 통해 들어온 Pointer는 객체가 관리하게 되므로 호출자에서 delete해서는 안된다.
	int Load(IMessageInfo *pMessageInfo);
	int Load(const CString& strXML);
private:
	const CString GetHeader();
	const CString GetMessageTypeString();
	int GetCommandFromXML(const CString& strXML);
	int GetMessageTypeFromXML(const CString& strXML);
	bool ParseHeader(const CString& strXML);
private:
	IMessageInfo * m_pInfo;
private:
//-. Header Information
	CString m_strSourceEquipment;
	CString m_strSourceUnit;
	CString m_strDestinationEquipment;
	CString m_strDestinationUnit;
};
