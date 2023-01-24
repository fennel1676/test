#pragma once

interface IMessageInfo
{
	virtual ~IMessageInfo() {} 
protected:
	int m_nMessageType;
	int m_nMessageCommand;

public:
	int GetMessageType() const		{ return m_nMessageType; }
	int GetMessageCommand() const	{ return m_nMessageCommand; }
	virtual const CString GetMsg() = 0;
	virtual bool ParseMsg(const CString& strXML) = 0;

	//�� Method�� ����Ͽ� return���� Pointer�� ȣ�����ʿ��� delete���־�� �Ѵ�.
	static IMessageInfo* CreateInfo(int nCommand);

};