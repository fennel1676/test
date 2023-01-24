extern "C" __declspec(dllimport) int _SMPD_ProcessInitial(char *hostIP, char *configFileName, 
													  NewDataCallBackType *pfn1Event, 
													  StatusChangeCallBackType *pfn2Event,
													  char* chSMDFilePath);
extern "C" __declspec(dllimport) void _SMPD_ProcessEnd();
extern "C" __declspec(dllimport) int _SMPD_NodeWrite(int nStrLenth, char *chWriteData, char* chNodeRoot,
														 char* chNodeFirst = NULL, char* chNodeSecond = NULL, 
														 char* chNodeThird = NULL, char* chNodeFourth = NULL );
extern "C" __declspec(dllimport) int  _SMPD_NodeRead(int nReadLength, char* chReadReturn, char* chNodeRoot,
														 char* chNodeFirst = NULL, char* chNodeSecond = NULL, 
														 char* chNodeThird = NULL, char* chNodeFourth = NULL);
/*
*	Module Name			:	nZGetNumberOfAllVariables
*	Parameter			:	없음
*	Return				:	Variables 개수.
*	Function			:	Tag 의 총 개수
*							
*	Create				:	2008.01.21
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdGetNumberOfAllVariables();

/*
*	Module Name			:	n_EtAdGetAllVariableIds
*	Parameter			:	Tag ID
*	Return				:	Variables 개수.
*	Function			:	Size만큼 buff로 값을 가져옴
*							
*	Create				:	2008.01.21
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdGetAllVariableIds(int *buff, int size);

/*
*	Module Name			:	n_EtAdGetVariableBaseTypeName
*	Parameter			:	Tag ID
*	Return				:	BaseType을 리턴(DINT,INT,SINT,BOOL,REAL)
*	Function			:	Varid로 BaseType을 가져옴
*							
*	Create				:	2008.01.21
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) char *n_EtAdGetVariableBaseTypeName(int variableId);

/*
*	Module Name			:	n_EtAdGetVariableName
*	Parameter			:	Tag ID
*	Return				:	Tag Name
*	Function			:	Varid로 TagName을 가져옴
*							
*	Create				:	2008.01.21
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) const char *n_EtAdGetVariableName(int variableId);

/*
*	Module Name			:	n_EtAdGetVariableLength
*	Parameter			:	Tag ID
*	Return				:	Var Length
*	Function			:	Varid로 Length를 가져옴
*							
*	Create				:	2008.01.21
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdGetVariableLength(int variableId);

/*
*	Module Name			:	n_EtAdIsVariableProduced
*	Parameter			:	Tag ID
*	Return				:	Produce이면 TRUE, 아니면 FALSE
*	Function			:	Produce인지 아닌지 확인
*							
*	Create				:	2008.01.21
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) BOOL n_EtAdIsVariableProduced(int variableId);

/*
*	Module Name			:	n_EtAdIsVariableConsumed
*	Parameter			:	Tag ID
*	Return				:	Consume이면 TRUE, 아니면 FALSE
*	Function			:	Consume인지 아닌지 확인
*							
*	Create				:	2008.01.21
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) BOOL n_EtAdIsVariableConsumed(int variableId);

/*
*	Module Name			:	n_EtAdIsVariableOnline
*	Parameter			:	Tag ID
*	Return				:	Consume이 Online이면 TRUE, 아니면 FALSE
*	Function			:	Consume의 Online 상태확인
*							
*	Create				:	2008.01.21
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) BOOL n_EtAdIsVariableOnline(int variableId);

/*
*	Module Name			:	n_EtAdIsVariableOnline
*	Parameter			:	Tag ID
*	Return				:	Consume이 Online이면 TRUE, 아니면 FALSE
*	Function			:	Consume의 Online 상태확인
*							
*	Create				:	2008.01.21
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) BOOL n_EtAdIsVariableOnline(int variableId);

/*
*	Module Name			:	n_EtAdGetNumberOfConnections
*	Parameter			:	Tag ID
*	Return				:	Digit : 연결된 개 수.
*	Function			:	현재 연결된 Consume 개 수.
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdGetNumberOfConnections(int nTagID);

/*
*	Module Name			:	n_EtAdTriggerProducingVariable
*	Parameter			:	Tag ID
*	Return				:	Produce가 아니면 FALSE, Trigged가 수행되면 TRUE
*	Function			:	현재 연결된 Consume 개 수.
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
//extern "C" __declspec(dllimport) BOOL n_EtAdTriggerProducingVariable(int variableId);

/*
*	Module Name			:	n_EtAdReadVariableDintValue
*	Parameter			:	Tag ID
*	Return				:	Read 한 개수
*	Function			:	DINT Type을 Read
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReadVariableDintValue(int variableId, INT32 *pv, int pl);

/*
*	Module Name			:	n_EtAdReadVariableIntValue
*	Parameter			:	Tag ID
*	Return				:	Read 한 개수
*	Function			:	INT Type을 Read
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReadVariableIntValue(int variableId, INT16 *pv, int pl);

/*
*	Module Name			:	n_EtAdReadVariableIntValue
*	Parameter			:	Tag ID
*	Return				:	Read 한 개수
*	Function			:	SINT Type을 Read
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReadVariableSintValue(int variableId, INT8 *pv, int pl);

/*
*	Module Name			:	n_EtAdReadVariableBoolValue
*	Parameter			:	Tag ID
*	Return				:	Read 한 개수
*	Function			:	BOOL Type을 Read
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReadVariableBoolValue(int variableId, BOOL *pv, int pl);

/*
*	Module Name			:	n_EtAdReadVariableRealValue
*	Parameter			:	Tag ID
*	Return				:	Read 한 개수
*	Function			:	REAL Type을 Read
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReadVariableRealValue(int variableId, float *pv, int pl);

/*
*	Module Name			:	n_EtAdWriteVariableDintValue
*	Parameter			:	Tag ID
*	Return				:	Write 한 개수
*	Function			:	DINT Type을 Write
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdWriteVariableDintValue(int variableId, INT32 *pv, int pl);

/*
*	Module Name			:	n_EtAdWriteVariableIntValue
*	Parameter			:	Tag ID
*	Return				:	Write 한 개수
*	Function			:	INT Type을 Write
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdWriteVariableIntValue(int variableId, INT16 *pv, int pl);

/*
*	Module Name			:	n_EtAdWriteVariableSintValue
*	Parameter			:	Tag ID
*	Return				:	Write 한 개수
*	Function			:	SINT Type을 Write
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdWriteVariableSintValue(int variableId, INT8 *pv, int pl);

/*
*	Module Name			:	n_EtAdWriteVariableBoolValue
*	Parameter			:	Tag ID
*	Return				:	Write 한 개수
*	Function			:	BOOL Type을 Write
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdWriteVariableBoolValue(int variableId, BOOL *pv, int pl);

/*
*	Module Name			:	n_EtAdWriteVariableRealValue
*	Parameter			:	Tag ID
*	Return				:	Write 한 개수
*	Function			:	REAL Type을 Write
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdWriteVariableRealValue(int variableId, float *pv, int pl);

/*
*	Module Name			:	n_EtAdSendVariableDintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Send DINT
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendVariableDintValue(char *ioAddress, char *varName, INT32 *pv, int pl);

/*
*	Module Name			:	n_EtAdSendVariableIntValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Send INT
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendVariableIntValue(char *ioAddress, char *varName, INT16 *pv, int pl);

/*
*	Module Name			:	n_EtAdSendVariableSintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Send SINT
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendVariableSintValue(char *ioAddress, char *varName, INT8 *pv, int pl);

/*
*	Module Name			:	n_EtAdSendVariableBoolValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Send BOOL
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendVariableBoolValue(char *ioAddress, char *varName, BOOL *pv, int pl);

/*
*	Module Name			:	n_EtAdSendVariableRealValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Send BOOL
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendVariableRealValue(char *ioAddress, char *varName, float *pv, int pl);

/*
*	Module Name			:	n_EtAdReceiveVariableDintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Receive DINT
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveVariableDintValue(char *ioAddress, char *varName, INT32 *pv, int pl);

/*
*	Module Name			:	n_EtAdReceiveVariableIntValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Receive INT
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveVariableIntValue(char *ioAddress, char *varName, INT16 *pv, int pl);

/*
*	Module Name			:	n_EtAdReceiveVariableSintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Receive SINT
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveVariableSintValue(char *ioAddress, char *varName, INT8 *pv, int pl);

/*
*	Module Name			:	n_EtAdReceiveVariableBoolValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Receive BOOL
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveVariableBoolValue(char *ioAddress, char *varName, BOOL *pv, int pl);

/*
*	Module Name			:	n_EtAdReceiveVariableRealValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Receive REAL
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveVariableRealValue(char *ioAddress, char *varName, float *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialDintVariableRead
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start위치부터 Read(DINT)
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialDintVariableRead(int variableId, int index, INT32 *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialIntVariableRead
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start위치부터 Read(INT)
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialIntVariableRead(int variableId, int index, INT16 *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialSintVariableRead
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start위치부터 Read(SINT)
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialSintVariableRead(int variableId, int index, INT8 *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialBoolVariableRead
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start위치부터 Read(BOOL)
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialBoolVariableRead(int variableId, int index, BOOL *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialRealVariableRead
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start위치부터 Read(REAL)
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialRealVariableRead(int variableId, int index, float *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialDintVariableWrite
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start위치부터 Write(DINT)
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialDintVariableWrite(int variableId, int index, INT32 *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialIntVariableWrite
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start위치부터 Write(INT)
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialIntVariableWrite(int variableId, int index, INT16 *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialSintVariableWrite
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start위치부터 Write(SINT)
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialSintVariableWrite(int variableId, int index, INT8 *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialBoolVariableWrite
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start위치부터 Write(BOOL)
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialBoolVariableWrite(int variableId, int index, BOOL *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialRealVariableWrite
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start위치부터 Write(REAL)
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialRealVariableWrite(int variableId, int index, float *pv, int pl);

/*
*	Module Name			:	n_EtAdOpenClass3Connection
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Connection
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdOpenClass3Connection(char *ioAddress, int rate);

/*
*	Module Name			:	n_EtAdReceiveClass3VariableDintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Receive DINT
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveClass3VariableDintValue(int connectionId, char *srcVarName, int srcVarLen, int destVarId);

/*
*	Module Name			:	n_EtAdReceiveClass3VariableIntValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Receive INT
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveClass3VariableIntValue(int connectionId, char *srcVarName, int srcVarLen, int destVarId);

/*
*	Module Name			:	n_EtAdReceiveClass3VariableSintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Receive SINT
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveClass3VariableSintValue(int connectionId, char *srcVarName, int srcVarLen, int destVarId);

/*
*	Module Name			:	n_EtAdReceiveClass3VariableRealValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Receive REAL
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveClass3VariableRealValue(int connectionId, char *srcVarName, int srcVarLen, int destVarId);

/*
*	Module Name			:	n_EtAdSendClass3VariableDintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Send DINT
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendClass3VariableDintValue(int connectionId, char *destVarName, int destVarLen, int srcVarId);

/*
*	Module Name			:	n_EtAdSendClass3VariableIntValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Send INT
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendClass3VariableIntValue(int connectionId, char *destVarName, int destVarLen, int srcVarId);

/*
*	Module Name			:	n_EtAdSendClass3VariableSintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Send SINT
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendClass3VariableSintValue(int connectionId, char *destVarName, int destVarLen, int srcVarId);

/*
*	Module Name			:	n_EtAdSendClass3VariableRealValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Send REAL
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendClass3VariableRealValue(int connectionId, char *destVarName, int destVarLen, int srcVarId);

/*
*	Module Name			:	n_EtAdCloseConnection
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Close
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) BOOL n_EtAdCloseConnection(int connectionId);

/*
*	Module Name			:	n_EtAdGetConnectionIds
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 연결된 id들을 리턴
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) void n_EtAdGetConnectionIds(int maxBufSize, int *buf, int *size);

/*
*	Module Name			:	n_EtAdGetConnectionInfo
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 연결 정보
*							
*	Create				:	2008.01.18
*	Author				:	고정진
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) BOOL n_EtAdGetConnectionInfo(int connectionId, ConnectionType *type, int *localVarId, int *transportType, 
															  UINT32 *receiveIPAddr, UINT32 *transmitIPAddr, int *rate, long *uptime);





// 사용유/무 확인필요
// extern "C" __declspec(dllimport) int nZReceiveVariable(char *hostIP, char* chSrcTag, char* chDataID);
// extern "C" __declspec(dllimport) int nSendVariable(char *hostIP, char* chSrcTag, char* chDataID);

