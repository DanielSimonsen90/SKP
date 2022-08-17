import { createContext, useContext, useEffect, useMemo, useState } from 'react';
import { BaseProps, StateObj, useSessionStorage } from 'danholibraryrjs';
import { Admin } from 'danhosaurportfolio-models';
import { api } from './MeProvider';

type AdminContextType = StateObj<Admin, 'Admin'> & Record<'isAdmin', boolean>;
const BaseAdmin: AdminContextType = {
    admin: null,
    setAdmin: () => { },
    isAdmin: false,
}

var LastAdminRequest = new Date();

const AdminContext = createContext(BaseAdmin);
export const useAdmin = (): AdminContextType => useContext(AdminContext);
export const useFindAdmin = () => async (username: string) => {
    if (!username) return null;
    else if (new Date(LastAdminRequest.getTime() + 1000 * 5).getTime() > new Date().getTime()) return null;

    LastAdminRequest = new Date();

    const admins: Array<Admin> = await api.get('admins').catch(err => {
        alert(err);
        return [];
    });

    return admins?.find(admin => admin.username === username);
}

export default function AdminProvider({ children }: BaseProps) {
    const [localAdmin, setLocalAdmin, removeLocalAdmin] = useSessionStorage<'admin', Admin>('admin', null);
    const findAdmin = useFindAdmin();
    const [admin, setAdmin] = useState(localAdmin);
    const isAdmin = useMemo(() => admin?.username && findAdmin(admin.username) != null, [admin]);

    console.trace('AdminProvider', admin, isAdmin);

    useEffect(() => {
        if (!isAdmin) removeLocalAdmin();
        else setLocalAdmin(admin);
    }, [isAdmin])

    return (
        <AdminContext.Provider value={{ admin, setAdmin, isAdmin }}>
            {children}
        </AdminContext.Provider>
    );
}