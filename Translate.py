import translate
import requests
import googletrans

RIGHT_LEFT_LANGUAGES = ['he', 'iw']

def googletrans_translate(text_to_translate, dest_language):
    #dest_language: for Hebrew input 'he' or 'iw'
    right_left = dest_language in RIGHT_LEFT_LANGUAGES
    #set setting to translate
    translator = googletrans.Translator()
    #translate the text
    translation = translator.translate(text_to_translate, dest=dest_language).text
    return translation, right_left


def translate_lib(text_to_translate, dest_language):
    #dest_language: for Hebrew input 'Hebrew' and not 'iw'
    right_left = dest_language == 'Hebrew'
    #set setting to translate
    translator= translate.Translator(to_lang=dest_language, from_lang='en')
    #translate the text
    translation = translator.translate(text_to_translate)

    return translation, right_left

def translate_post(word_to_translate, dest_language):
    right_left = dest_language == 'iw'
    url = 'https://www.webtran.eu/gtranslate/'
    data_translate = {'text' : word_to_translate, 'gfrom' : 'en', 'gto' : dest_language}
    translate_words = requests.post(url, data=data_translate)
    return translate_words.text, right_left
