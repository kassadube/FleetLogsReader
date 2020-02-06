--select * from LogTBL

--truncate table LogTBL

select * from LogTBL order by Message desc

select * from LogTBL order by LogType desc

select COUNT(*) from LogTBL where LogType ='DBTrace'
select COUNT(*) from LogTBL where LogType ='Trace'
select COUNT(*) from LogTBL where LogType ='Warn'
select COUNT(*) from LogTBL where LogType ='JSError'
select COUNT(*) from LogTBL where LogType ='Fatal'
select * from LogTBL where LogType ='Fatal'

declare
	@LogServer  NVARCHAR(50)  = 'sdfsdf',
	@param2 int

	 
	SELECT  * from LogTBL where LogServer =@LogServer