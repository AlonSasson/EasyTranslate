from deep_translator import GoogleTranslator

RIGHT_LEFT_LANGUAGES = ['he', 'iw']


def googletrans_translate(text_to_translate, dest_language):
    # dest_language: for Hebrew input 'he' or 'iw'

    right_left = dest_language.lower() in RIGHT_LEFT_LANGUAGES
    if text_to_translate == '' or dest_language == 'english':  # if there is nothing to translate
        return text_to_translate, right_left
    # set settings for translation
    translator = GoogleTranslator(source='english', target=dest_language)

    # translate the text
    translation = translator.translate(text_to_translate)
    return translation, right_left

