#pragma once

#include "../MessageInfo.h"

namespace Message
{
	class CMsgPLCDataEvent : public IMessageInfo
	{

	public:
		CMsgPLCDataEvent(void);
		virtual ~CMsgPLCDataEvent(void);

	public:
		virtual const CString GetMsg();
		virtual bool ParseMsg(const CString& strXML) { return false; }

	public:
		int m_nPort;
		int m_nCommandID;
		int m_nByWho;
		CString m_strCSTID;
		int m_nMap_Stif;
		int m_nStart_Stif;
	};
}
