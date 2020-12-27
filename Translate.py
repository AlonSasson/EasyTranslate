import requests
def translate_post(word_to_translate):
    url = 'https://www.webtran.eu/gtranslate/'
    data_translate = {'text' : word_to_translate, 'gfrom' : 'en', 'gto' : 'iw'}
    translate_words = requests.post(url, data=data_translate)
    return translate_words.text