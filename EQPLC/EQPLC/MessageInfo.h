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

	//이 Method를 사용하여 return받은 Pointer는 호출자쪽에서 delete해주어야 한다.
	static IMessageInfo* CreateInfo(int nCommand);

};