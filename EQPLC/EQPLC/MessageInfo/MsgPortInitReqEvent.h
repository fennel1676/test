#pragma once

#include "../MessageInfo.h"

namespace Message
{
	class CMsgPortInitReqEvent : public IMessageInfo
	{

	public:
		CMsgPortInitReqEvent(void);
		virtual ~CMsgPortInitReqEvent(void);

	public:
		virtual const CString GetMsg();
		virtual bool ParseMsg(const CString& strXML) { return false; }

	public:
		int m_nPort;
	};
}
