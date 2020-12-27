import urllib.request
import urllib.parse
import time
import re

values = {'sl':'en','tl':'iw','text':'word bla bla'}
url = 'https://translate.google.com/?'

data = urllib.parse.urlencode(values)
print(url + data)

req = urllib.request.Request(url + data)
time.sleep(3)
resp = urllib.request.urlopen(req)

respData = resp.read()

print(respData)

spna_serche = r'<div(.*?)></div>'

span = re.findall(spna_serche, str(respData))
for i in span:
    if i.find('"wi"') != -1:
        print(i)