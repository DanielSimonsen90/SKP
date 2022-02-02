import React from 'react'
import { useTranslate } from 'providers/LanguageProvider'
import LinkItem from './LinkItem'

export default function ToTop() {
    const translate = useTranslate();
    return <LinkItem className='to-top' title={translate('top')} link="#" />
}
