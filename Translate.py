import requests
def translate_post(word_to_translate, dest_language):
    right_left = dest_language == 'iw'
    url = 'https://www.webtran.eu/gtranslate/'
    data_translate = {'text' : word_to_translate, 'gfrom' : 'en', 'gto' : dest_language}
    translate_words = requests.post(url, data=data_translate)
    return translate_words.text, right_left
