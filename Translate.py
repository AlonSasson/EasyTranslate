from translate import Translator
import requests
import time



def translate_lib(text_to_translate, dest_language):
    #dest_language: for Hebrew input 'Hebrew' and not 'iw'

    #set setting to translate
    translator= Translator(to_lang=dest_language, from_lang='en')
    #translate the text
    translation = translator.translate("The quick brown fox jumps over the lazy dog")

    return translation

def translate_post(word_to_translate, dest_language):
    right_left = dest_language == 'iw'
    url = 'https://www.webtran.eu/gtranslate/'
    data_translate = {'text' : word_to_translate, 'gfrom' : 'en', 'gto' : dest_language}
    translate_words = requests.post(url, data=data_translate)
    return translate_words.text, right_left
