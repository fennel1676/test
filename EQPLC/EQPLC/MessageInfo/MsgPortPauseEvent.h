#pragma once

#include "../MessageInfo.h"

namespace Message
{
	class CMsgPortPauseEvent : public IMessageInfo
	{

	public:
		CMsgPortPauseEvent(void);
		virtual ~CMsgPortPauseEvent(void);

	public:
		virtual const CString GetMsg();
		virtual bool ParseMsg(const CString& strXML) { return false; }

	public:
		int m_nPort;
	};
}
