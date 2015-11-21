var vm = (function(ko) {
            return ko.applyBindings(new CustomerViewModel)

            function CustomerViewModel() {
                this.id = ko.observable("").extend({ trackChange: true });
                this.name = ko.observable("").extend({ trackChange: true });
                this.streetNumber = ko.observable("").extend({ trackChange: true });
                this.streetName = ko.observable("").extend({ trackChange: true });
                this.phoneNumber = ko.observable("").extend({ trackChange: true });
                this.city = ko.observable("").extend({ trackChange: true });
                this.notes = ko.observable("").extend({ trackChange: true });
                this.getUser = function getUser() {
                    $.ajax({
                        url: "/Customers/" + this.id(),
                        type: "GET",
                        data: {},
                        dataType: 'json',
                        success: function(data) {
                                applyUser.apply(this, [data]);
                        }.bind(this),
                        error: function(data) {
                            alert(data);
                        }.bind(this)
                    });
                }
                function applyUser(user) {
                    this.name(user.Name);
                    this.streetNumber(user.StreetNumber);
                    this.streetName(user.StreetName);
                    this.phoneNumber(user.PhoneNumber);
                    this.city(user.City);
                    this.notes(user.Notes);
                    cleanAll.call(this);
                }
                function cleanAll() {
                    for (key in this) {
                        var member = this[key];
                        if (this.hasOwnProperty(key) && ko.isObservable(member) && typeof member.isDirty === 'function') {
                            member.isDirty(false);
                        }
                    }
                }
                this.saveUser = function saveUser() {
                    alert("I have no function.");
                }
            }
        })(ko);