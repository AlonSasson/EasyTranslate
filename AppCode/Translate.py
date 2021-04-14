from deep_translator import GoogleTranslator

RIGHT_LEFT_LANGUAGES = ['hebrew', 'arabic']


def googletrans_translate(text_to_translate, dest_language):
    """
    Translates text in English to a different language
    :param text_to_translate: the English text to translate
    :param dest_language: the language to translate the text to
    :return: the translated text, and whether the language is written from right to left
    """
    right_left = dest_language.lower() in RIGHT_LEFT_LANGUAGES
    if text_to_translate == '' or dest_language.lower() == 'english':  # if there is nothing to translate
        return text_to_translate, right_left
    # set settings for translation
    translator = GoogleTranslator(source='english', target=dest_language)

    # translate the text
    translation = translator.translate(text_to_translate)
    return translation, right_left

