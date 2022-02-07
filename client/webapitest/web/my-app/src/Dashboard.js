import React, { Component } from 'react';
import './App.css';
import { Button, Card, CardBody, CardGroup, Col, Container, Form, 
         Input, InputGroup, InputGroupAddon, InputGroupText, Row } from 'reactstrap';
  class Dashboard extends Component {
    render() {
 
        return (
            <div class="row" className="mb-2 pageheading">
                <div class="col-sm-12 btn btn-primary">
                    Dashboard 
             </div>
            </div>
        );
    }
}
 
export default Dashboard;