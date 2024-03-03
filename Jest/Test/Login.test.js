// LoginComponent.test.js
import React from 'react';
import { render, fireEvent } from '@testing-library/react';
import axios from 'axios';
import { screen } from '@testing-library/react';
import { BrowserRouter, MemoryRouter, Routes, useNavigate, Route,Router } from 'react-router-dom';
import  LoginComponent  from '../Component/LoginComponent';

// mock axios and useNavigate
jest.mock('axios');
jest.mock('react-router-dom', () => ({ useNavigate: jest.fn() }));



test('RENDER THE LOGIN FORM CHECK LABEL', async () => {
    const { getByLabelText } =
        render(<LoginComponent />);
    expect(getByLabelText('Enter a email')).toBeInTheDocument();
    expect(getByLabelText('Enter a password')).toBeInTheDocument();
});
test('RENDER THE LOGIN FORM CHECK BUTTON EXISTS', async () => {
    const { getByText } =
        render(<LoginComponent />);
   expect(getByText('Login')).toBeInTheDocument();
    expect(getByText('Register')).toBeInTheDocument();
    

});

  test('shows error messages if email or password is empty', () => {
    // render the component
    const { getByText ,getByTestId} = render(<LoginComponent/>);
    // get the elements
    
    const loginButton = getByText('Login');
    // click the login button
    fireEvent.click(loginButton);
    // check if the error messages are shown
    expect(getByTestId('useremailerror')).toHaveTextContent('Please enter a email');
    expect(getByTestId('userpwderror')).toHaveTextContent('Please enter a password');
  });


  test('calls post axios if the login is successful', async () => {
    // render the component
    const { getByText,getByRole } = render(<LoginComponent/>);
    // get the elements
    const emailInput = getByRole('logininput1', { id: 'UserEmail' });
    const passwordInput = getByRole('logininput2', { id: 'UserPassword' });
    const loginButton = getByText('Login');
    // enter some valid data
    fireEvent.change(emailInput, { target: { value: 'Karthick@gmail.com' } });
    fireEvent.change(passwordInput, { target: { value: 'Karthick123' } });
    // mock the axios.post response
    axios.post.mockResolvedValue({ data: { account: true, emailstatus: true, passwordstatus: true } });
    // mock the useNavigate function
    const navigate = useNavigate();
    // click the login button
    fireEvent.click(loginButton);
    // wait for the axios.post call
    await expect(axios.post).toHaveBeenCalled();
  
  });

