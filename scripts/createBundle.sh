dotnet restore
dotnet publish -o site -c Release -r win-x64 --self-contained
cd site
zip ../site.zip *
cd ../
zip bundle.zip site.zip aws-windows-deployment-manifest.json
rm -r site
rm site.zip
mv bundle.zip ./bin
