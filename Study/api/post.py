import requests
import time



url = 'https://www.webtran.eu/gtranslate/'
data_translate = {'text' : 'Hello my name is ron', 'gfrom' : 'en', 'gto' : 'iw', 'key' : 'ABC',}

start_time = time.time()
x = requests.post(url, data = data_translate)
print("--- %s seconds ---" % (time.time() - start_time))

print(x.text)