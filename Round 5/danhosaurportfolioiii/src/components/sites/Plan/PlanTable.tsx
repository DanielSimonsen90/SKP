import { useTranslate } from "providers/LanguageProvider";
import { PlanProps } from ".";
import PlanRow from "./PlanRow";

export default function PlanTable({ titles, planData }: PlanProps) {
    const translate = useTranslate();

    return (
        <table>
        <thead>
            <tr>
                {titles.map((key, i) => <th key={i}>{translate(key)}</th>)}
            </tr>
        </thead>
        <tbody>
            {planData.map((item, i) => <PlanRow key={i} item={item} />)}
        </tbody>
    </table>
    );
}