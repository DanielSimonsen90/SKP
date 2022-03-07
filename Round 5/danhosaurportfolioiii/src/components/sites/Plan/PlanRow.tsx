import { useMemo } from 'react';
import { PlanItemProps, PlanRowProps, usePlanItemData } from '.'

type Props = PlanRowProps & PlanItemProps;

export default function PlanRow({ item, planData }: Props) {
    const { course, start, end, duration, courseType, dataCurrentOccupation } = usePlanItemData(item);
    const rowData = [course, start, end, duration].map((v, i) => (
        i === 1 || i === 2 ? (
            <time dateTime={v.split('/').reverse().join('-')}>{v}</time>
        ) : <>{v}</>
    ));

    const cells = useMemo(() => rowData.map((cell, i) => (
        <td key={i} className="plan-cell">{cell}</td>
    )), [planData]);
    const visible = useMemo(() => planData.find(d => d.course === course), [planData, item]);

    return (
        <tr data-course={courseType} className={visible ? 'visible' : 'hidden'}  {...{ 'data-current-occupation': dataCurrentOccupation }}>
            {cells}
        </tr>
    )
}
