#ifndef _ASADAPTER_DEPTH_DEFINE_H
#define _ASADAPTER_DEPTH_DEFINE_H

#define		USER_TYPE_DINT		0
#define		USER_TYPE_INT		1
#define		USER_TYPE_SINT		2
#define		USER_TYPE_STRING	3
#define		USER_TYPE_BOOL		4
#define		USER_TYPE_REAL		5


#define		MAX_VAL_NAME	64
#define		MAX_CHILD		256
#define		MAX_VAL			256
#define		MAX_DEPTH		5
#define		MAX_THREAD		200
#define		MAX_CONTENTS	256
#define		MAX_ROOT_COUNT	2048 //256

typedef struct 
{
	int		nIndex;
	char	chSection[MAX_VAL_NAME];
	char	chMother[MAX_VAL_NAME];
	char	chID[MAX_VAL_NAME];
	int		nStart;
	int		nLen;
	int		nType;
}SLINKTREE_ITEM, *LPSLINKTREE_ITEM;

typedef struct _SLINKTREE
{
	int		nCount;
	_SLINKTREE	*pParent;
	_SLINKTREE	*pChild[MAX_CHILD];
	LPSLINKTREE_ITEM pItem;
}SLINKTREE, *LPSLINKTREE;

typedef struct 
{
	HANDLE	hHandle;
	LPDWORD	pId;
	BOOL	bLive;
	int		nPeriod;
	char	chContents[MAX_CONTENTS];
} STHREADSTRUCT, *LPSTHREADSTRUCT;


typedef struct _SROOT_LIST
{
	int			nIndex;
	HTREEITEM	hRoot;
} SROOT_LIST, *LPSROOT_LIST;

typedef struct 
{
	char	chRT_1[MAX_VAL_NAME];
	char	chN1_1[MAX_VAL_NAME];
	char	chN2_1[MAX_VAL_NAME];
	char	chN3_1[MAX_VAL_NAME];
	char	chN4_1[MAX_VAL_NAME];
	char	chRT_2[MAX_VAL_NAME];
	char	chN1_2[MAX_VAL_NAME];
	char	chN2_2[MAX_VAL_NAME];
	char	chN3_2[MAX_VAL_NAME];
	char	chN4_2[MAX_VAL_NAME];
	int		nType;
	int		nStart;
	int		nEnd;
	int		nPeriod;
} SCYCLE_VALLIST, *LPSCYCLE_VALLIST;

typedef struct
{
	BOOL	nConn;
	int		nId;
	int		nRate;
	char	chIp[MAX_VAL_NAME];
} SCLASS3CONNECT, *LPSCLASS3CONNECT;

typedef void NewDataCallBackType( int variableId );		    /* Callback function to be called in case of any new data written into a table */
typedef void StatusChangeCallBackType( int variableId );	/* Callback function to be called in case of change of state for the variable */
#define INT8            char
#define UINT8           unsigned char
#define INT16           signed short
#define UINT16          unsigned short
#define INT32           signed int
#define UINT32          unsigned int
typedef enum tagConnectionType
{
	UnusedConnType,
		UnknownConnType,
		Class1Producing,
		Class1Consuming,
		Class3Serving,
		Class3Client,
		TimeOutConnType
} ConnectionType;
#endif