import googletrans

RIGHT_LEFT_LANGUAGES = ['he', 'iw']

def googletrans_translate(text_to_translate, dest_language):
    #dest_language: for Hebrew input 'he' or 'iw'

    right_left = dest_language.lower() in RIGHT_LEFT_LANGUAGES
    #set setting to translate
    translator = googletrans.Translator()
    #translate the text
    translation = translator.translate(text_to_translate, dest=dest_language).text
    return translation, right_left

