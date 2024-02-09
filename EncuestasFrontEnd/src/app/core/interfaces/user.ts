export interface User {
    id?: string;
    username: string;
    password: string;
    firstName: string;
    lastName: string;
    role: string;
}

export interface PostUser {
    firstName: string;
    lastName: string;
    username: string;
    password: string;
}

export interface PutUser {
    id?: number;
    username: string;
    password: string;
    firstName: string;
    lastName: string;
}

export interface DeleteUser {
    id?: number;
}


export interface signIn{
    username: string;
    password: string;
}

export interface signInResponse{
    title: string;
    message: string;
    status: number;
}


export interface signUp{
}