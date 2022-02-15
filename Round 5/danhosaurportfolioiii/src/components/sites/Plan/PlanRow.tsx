import { PlanItemProps, usePlanItemData } from '.'

type Props = PlanItemProps;

export default function PlanRow({ item }: Props) {
    const { course, start, end, duration, courseType, dataCurrentOccupation } = usePlanItemData(item);
    const rowData = [course, start, end, duration];

    return (
        <tr data-course={courseType} {...{ 'data-current-occupation': dataCurrentOccupation }}>
            {rowData.map((cell, i) => <td key={i} className="plan-cell">{cell}</td>)}
        </tr>
    )
}
