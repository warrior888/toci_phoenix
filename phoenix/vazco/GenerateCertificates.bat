mkdir C:\CertTest\
makecert -a SHA1 -r -pe -n "CN=CertyfikatTestowy01" -e 01/01/2050 -sky signature -ss my C:\CertTest\CertyfikatTestowy01.cer
makecert -a MD5 -r -pe -n "CN=CertyfikatTestowy02" -e 01/01/2050 -sky signature -ss my C:\CertTest\CertyfikatTestowy02.cer
makecert -a sha256 -r -pe -n "CN=CertyfikatTestowy03" -e 01/01/2050 -sky signature -ss my C:\CertTest\CertyfikatTestowy03.cer
makecert -a sha384 -r -pe -n "CN=CertyfikatTestowy04" -e 01/01/2050 -sky signature -ss my C:\CertTest\CertyfikatTestowy04.cer
makecert -a shA512 -r -pe -n "CN=CertyfikatTestowy05" -e 01/01/2050 -sky signature -ss my C:\CertTest\CertyfikatTestowy05.cer
makecert -a SHA1 -r -n "CN=CertyfikatTestowy06" -e 01/01/2050 -sky signature -ss my C:\CertTest\CertyfikatTestowy06.cer
makecert -a sha256 -r -pe -r -n  "CN=CertyfikatTestowy07" -e 01/01/2050 -sky signature -ss my C:\CertTest\CertyfikatTestowy07.cer
