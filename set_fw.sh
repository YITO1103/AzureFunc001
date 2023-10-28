#!/bin/bash
export c_access_token=$(curl -s -X POST "https://login.microsoftonline.com/f0d32cc1-f40a-4607-88e3-34dfd6b564b6/oauth2/token" \
     -H "User-Agent: PostmanRuntime/7.34.0" \
     -H "Accept: */*" \
     -H "Content-Type: application/x-www-form-urlencoded" \
     -H "Cookie: buid=0.AT8AaTTQPPBTYkmmn3M6UbPbl5I4bj03YJ1KkaEaZ6UaNU1AAAA.AQABAAEAAAAtyolDObpQQ5VtlI4uGjEPADJikFB1bpwKgXQcYTpfq-WRZDmsVwsheYoMKz8Ex3XaryUipDpnN82e6ibGx0FUWZJVEbz18botnydBV9C1MuG3VhatbdQ_xsqxvQFryk0gAA; fpc=AoTJTsFAlXNMmsspxM9uxzZpI5hzAQAAAL3pztwOAAAA; stsservicecookie=estsfd; x-ms-gateway-slice=estsfd" \
     --data-urlencode "grant_type=client_credentials" \
     --data-urlencode "client_id=6f88413d-c5ff-47ba-886d-21708d451a30" \
     --data-urlencode "client_secret=npT8Q~c~nDj.ngXvbc~0cpgLCFdamH~a2rBmJbH_" \
     --data-urlencode "resource=https://management.azure.com/" | \
     grep -o '"access_token":"[^"]*"' | \
     awk -F':' '{print $2}' | \
     sed 's/^[ \t]*"//;s/"[ \t]*$//')


#echo ==$c_access_token==


# シェルの種類とOSを検出
shell=$(echo $SHELL | awk -F/ '{print $NF}')
os=$(uname)

# シェルの種類とOSを検出
shell=$(echo $SHELL | awk -F/ '{print $NF}')
os=$(uname)

# IPv4アドレスを取得し、環境変数にセット
if [ "$shell" = "bash" ] && [[ "$os" == MINGW* || "$os" == MSYS* ]]; then
  # Git Bash (Windows)
  export c_ipv4=$(ipconfig | grep -i "IPv4 Address" | cut -d: -f2 | tr -d '[:space:]')
elif [ "$os" = "Darwin" ]; then
  # macOS
  export c_ipv4=$(ifconfig | grep -w inet | grep -v inet6 | awk '{print $2}' | head -n 1)
elif [ "$CODESPACES" = "true" ]; then
  # GitHub Codespaces
  export c_ipv4=$(curl ifconfig.me)
else
  # その他のLinux
  export c_ipv4=$(ip -4 addr show | grep -oP '(?<=inet\s)\d+(\.\d+){3}' | head -n 1)
fi

echo "Detected OS: $os. IP is $c_ipv4"

#  export c_ipv4=$(curl ifconfig.me)
#echo "Detected OS: $os. IP is $c_ipv4"


curl -X PUT "https://management.azure.com/subscriptions/68dc2ed0-933d-46de-aea8-c054445c440f/resourceGroups/resource_group01/providers/Microsoft.Sql/servers/server-dev01/firewallRules/$(hostname)?api-version=2023-05-01-preview" \
     -H "Content-Type: application/json" \
     -H "Authorization: Bearer $c_access_token" \
     -d "{\"properties\": {\"startIpAddress\": \"$c_ipv4\",\"endIpAddress\": \"$c_ipv4\"}}"

unset c_access_token

