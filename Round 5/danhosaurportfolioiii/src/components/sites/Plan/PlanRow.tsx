import { Time } from 'danholibraryjs'
import { BaseProps } from 'danholibraryrjs'
import { ScheduleItem } from 'danhosaurportfolio-models'
import { useTranslate } from 'providers/LanguageProvider'
import { useMe } from 'providers/MeProvider'

type Props = BaseProps<HTMLDivElement, false> & {
    item: ScheduleItem
}

export default function PlanRow({ item, className }: Props) {
    const translate = useTranslate();
    const { occupation } = useMe();
    const durationString = (() => {
        const format = (time: number, type: 'month' | 'day') => `${time} ${translate(`${type}${time > 1 ? 's' : ''}`).toLowerCase()}`
        return `${format(item.duration.months, 'month')} & ${format((item.duration.getTotalDays() % Time.avgMonth), 'day')}`
    })()
    const rowData = [
        item.course, 
        item.start.toString(), 
        item.end.toString(), 
        durationString
    ]

    return (
        <tr className={`${className} ${item.course === occupation ? 'current-occupation' : ''}`}>
            {rowData.map((cell, i) => <td key={i} className="plan-cell">{cell}</td>)}
        </tr>
    )
}
