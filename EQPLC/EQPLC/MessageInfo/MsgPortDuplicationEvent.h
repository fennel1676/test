#pragma once

#include "../MessageInfo.h"

namespace Message
{
	class CMsgPortDuplicationEvent : public IMessageInfo
	{

	public:
		CMsgPortDuplicationEvent(void);
		virtual ~CMsgPortDuplicationEvent(void);

	public:
		virtual const CString GetMsg();
		virtual bool ParseMsg(const CString& strXML) { return false; }

	public:
		int m_nPort;
		CString m_strH_PanelID;
		CString m_strUniqueID;
		CString m_strResult1;
		CString m_strResult2;
		CString m_strResult3;

	};
}
