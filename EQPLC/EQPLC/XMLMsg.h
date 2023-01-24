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

	//�� Method�� ���� �޾ư� Pointer�� delete�ؼ��� �ȵȴ�.
	IMessageInfo* GetInfo() { return m_pInfo; }
public:
	//�� Method�� ���� ���� Pointer�� ��ü�� �����ϰ� �ǹǷ� ȣ���ڿ��� delete�ؼ��� �ȵȴ�.
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
