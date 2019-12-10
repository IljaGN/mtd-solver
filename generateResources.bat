@echo off
set $pathResGen=%~1
set $initPath=%cd%
for /f "tokens=2 delims=:" %%d in ('chcp') do set "ccp=%%d"
set $initCCP=%ccp:~1%
set $enUsCCP=437
set $resGen=resgen
if not "%~1"=="" (set $resGen=%$pathResGen%\%$resGen%)
set $fileName=Resources
set $resName=%$fileName%.Designer

cd "MTD Solver\Properties"
chcp %$enUsCCP%
%$resGen% %$fileName%.resx %$resName%.resources /str:cs,MTD_Solver.Properties,%$fileName% /publicClass
del %$resName%.resources /q
chcp %$initCCP%
cd "%$initPath%"
