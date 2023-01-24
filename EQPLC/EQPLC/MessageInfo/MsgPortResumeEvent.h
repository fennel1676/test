#pragma once

#include "../MessageInfo.h"

namespace Message
{
	class CMsgPortResumeEvent : public IMessageInfo
	{

	public:
		CMsgPortResumeEvent(void);
		virtual ~CMsgPortResumeEvent(void);

	public:
		virtual const CString GetMsg();
		virtual bool ParseMsg(const CString& strXML) { return false; }

	public:
		int m_nPort;
	};
}
