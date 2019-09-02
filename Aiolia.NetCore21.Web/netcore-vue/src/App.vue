<template>
    <div id="app">
        <header class="navbar navbar-expand navbar-dark flex-column flex-md-row bd-navbar"></header>
        <div class="container-fluid">
            <div class="row flex-xl-nowrap">
                <div class="col-12 col-md-3 col-xl-2 bd-sidebar">

                </div>
                <main class="col-12 col-md-9 col-xl-10 py-md-3 pl-md-5 bd-content">
                    <router-view />
                </main>
            </div>
        </div>
    </div>
</template>

<style lang="scss">
    .bd-content {
        -webkit-box-ordinal-group: 2;
        -ms-flex-order: 1;
        order: 1
    }



    .bd-sidebar {
        -webkit-box-ordinal-group: 1;
        -ms-flex-order: 0;
        order: 0;
        border-bottom: 1px solid rgba(0,0,0,.1)
    }

    @media (min-width:768px) {
        .bd-sidebar {
            border-right: 1px solid rgba(0,0,0,.1)
        }

        @supports ((position:-webkit-sticky) or (position:sticky)) {
            .bd-sidebar {
                position: -webkit-sticky;
                position: sticky;
                top: 4rem;
                z-index: 1000;
                height: calc(100vh - 4rem)
            }
        }
    }

    @media (min-width:1200px) {
        .bd-sidebar {
            -webkit-box-flex: 0;
            -ms-flex: 0 1 320px;
            flex: 0 1 320px
        }
    }

    .bd-navbar {
        min-height: 4rem;
        background-color: #563d7c;
        box-shadow: 0 .5rem 1rem rgba(0,0,0,.05),inset 0 -1px 0 rgba(0,0,0,.1)
    }

    @media (min-width:768px) {
        @supports ((position:-webkit-sticky) or (position:sticky)) {
            .bd-navbar {
                position: -webkit-sticky;
                position: sticky;
                top: 0;
                z-index: 1071
            }
        }
    }

    @media (max-width:991.98px) {
        .bd-navbar {
            padding-right: .5rem;
            padding-left: .5rem
        }

            .bd-navbar .navbar-nav-scroll {
                max-width: 100%;
                height: 2.5rem;
                margin-top: .25rem;
                overflow: hidden;
                font-size: .875rem
            }

                .bd-navbar .navbar-nav-scroll .navbar-nav {
                    padding-bottom: 2rem;
                    overflow-x: auto;
                    white-space: nowrap;
                    -webkit-overflow-scrolling: touch
                }
    }
</style>