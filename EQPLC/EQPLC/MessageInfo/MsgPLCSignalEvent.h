#pragma once

#include "../MessageInfo.h"

namespace Message
{
	class CMsgPLCSignalEvent : public IMessageInfo
	{

	public:
		CMsgPLCSignalEvent(void);
		virtual ~CMsgPLCSignalEvent(void);

	public:
		virtual const CString GetMsg();
		virtual bool ParseMsg(const CString& strXML) { return false; }

	public:
		int m_nPort;
		int m_nSigID;
		int m_nResult;
	};
}
