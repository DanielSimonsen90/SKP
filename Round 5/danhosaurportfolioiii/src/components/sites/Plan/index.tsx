import { useMemo, useState } from 'react'
import { ScheduleItem } from 'danhosaurportfolio-models';
import { useLocationCollection } from 'providers/MeProvider';
import { useTranslate } from 'providers/LanguageProvider';
import PlanRow from './PlanRow';
import Occupation from './Occupation';
import './Plan.scss'

type PlanStates = 'future' | 'full';

export default function Plan() {
    const locationCollection = useLocationCollection();
    const futurePlan = useMemo(() => {
        const result = new Array<ScheduleItem>();
        for (const item of locationCollection) {
            if (item.end.getTime() > Date.now())
                result.push(item)
        }
        return result;
        // return locationCollection.filter(i => i.end.getTime() > Date.now());
    }, [locationCollection])
    const translate = useTranslate();
    const [planState, setPlanState] = useState<PlanStates>('future');
    const [tableData, setTableData] = useState<Array<ScheduleItem>>(futurePlan)
    const titles = ['course', 'start', 'end', 'duration'].map(title => translate(title));
    
    const onChangeEducationPlanClicked = () => {
        const newState = planState === 'full' ? 'future' : 'full';
        setPlanState(newState);
        setTableData(newState === 'full' ? locationCollection : futurePlan);
    }

    return (
        <main id="plan-page">
            <div>
                <h1>{translate('educationPlanTitle')[planState]}</h1>
                <Occupation link={false} />
            </div>
            <button onClick={onChangeEducationPlanClicked}>{translate('changeEducatonPlanState')}</button>
            <table>
                <thead>
                    <tr>
                        {titles.map((key, i) => <th key={i}>{translate(key)}</th>)}
                    </tr>
                </thead>
                <tbody>
                    {tableData.map((item, i) => <PlanRow key={i} item={item} className={item.course === 'Grundforløb' ? item.course : item.course.substring(0, item.course.length - 2)} />)}
                </tbody>
            </table>
        </main>
    )
}
